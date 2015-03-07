using Data;
using HtmlAgilityPack;
using Newtonsoft.Json;
using ParseSite.Fin.ua;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace ParseSite
{

    class Program
    {
        private const string SITE = @"http://finance.i.ua/";
        private const string USD = @"usd/";
        private const string EUR = @"eur/";
        private const string RUB = @"rub/";

        static void Main(string[] args)
        {

            var cours = CParser.GetKursesFromFinUA(SITE, USD);
						var arr = cours.Select( (b, d)=>{ return new BankData() {bank=b.Key, kurs=b.Value}; }).ToArray();

						string res = JsonConvert.SerializeObject(arr, Formatting.None,new JsonSerializerSettings());

						System.IO.File.WriteAllText("result.json", res);

            Console.ReadKey();
        }
    }
}
