using ExchangeRates.Data;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace ParseSite.Fin.ua
{
    public class CParser
    {
        #region Universal

        public static HtmlNodeCollection ParseTable(string siteData, string baseElement)
        {
            HtmlDocument doc = new HtmlDocument();
            String text = siteData;

            doc.LoadHtml(text);
            return doc.GetElementbyId(baseElement).ChildNodes;
        }

        public static string Load(string site)
        {
            WebClient web = new WebClient();
            System.IO.Stream stream = web.OpenRead(site);
            var text = string.Empty;
            using (System.IO.StreamReader reader = new System.IO.StreamReader(stream, Encoding.GetEncoding("windows-1251")))
            {
                text = reader.ReadToEnd();
            }

            return text;
        }

        #endregion

        #region IFin.ua

        public static Dictionary<Bank, KursData> GetKursesFromFinUA(string site, string currency)
        {
            const string BaseID = @"feMain2";
            const string tableTag = "table";

            string link = site + currency;
            try
            {
                string text = CParser.Load(link);
                HtmlNodeCollection coll = CParser.ParseTable(text, BaseID);
                HtmlNode table = coll.FirstOrDefault(p => p.Name == tableTag);

                if (table == null)
                    return new Dictionary<Bank, KursData>();

                return Parse(table);
            }
            catch (Exception)
            {
                return new Dictionary<Bank, KursData>();
            }
        }

        public static Dictionary<Bank, KursData> Parse(HtmlNode table)
        {
            Dictionary<Bank, KursData> system = new Dictionary<Bank, KursData>();

            const string trTag = "tr";
            const string tdTag = "td";
            const string titleTag = "title";

            if (table == null)
                return system;

            var tabbleNodes = table.ChildNodes.Where(p => p.Name == trTag);

            foreach (var node in tabbleNodes)
            {
                var childs = node.ChildNodes.Where(p => p.Name == tdTag).ToArray();

                if (childs.Count() > 0)
                {
                    HtmlNodeCollection childsFirst = childs[0].ChildNodes;

                    if (childsFirst.Count < 2)
                        break;

                    string bankName = childsFirst[1].Attributes[titleTag].Value;
                    string lastData = childsFirst[0].InnerText;

                    Bank bank = new Bank(bankName, string.Empty);
                    KursData kurs = new KursData();

                    kurs.Buy = childs[1].InnerText;
                    kurs.Sale = childs[2].InnerText;
                    kurs.Date = lastData;

                    try
                    {
                        kurs.GrowthBuy = GetGrowthType(childs[1]);
                        kurs.GrowthSale = GetGrowthType(childs[2]);
                    }
                    catch (Exception) { }

                    system.Add(bank, kurs);
                }
            }
            return system;
        }

        private static StateType GetGrowthType(HtmlNode htmlNode)
        {
            var growthType = htmlNode.ChildNodes.FirstOrDefault(p => p.Name == "i");
            if (growthType != null && growthType.Attributes.Count > 0)
            {
                return GetTypeFromStrin(growthType.Attributes[0].Value);
            }
            return StateType.None;
        }

        private static StateType GetTypeFromStrin(string p)
        {
            if (p == "decrease")
            {
                return StateType.RaiseDown;
            }
            else if (p == "increase")
            {
                return StateType.Raise;
            }

            return StateType.None;
        }

        #endregion
    }
}
