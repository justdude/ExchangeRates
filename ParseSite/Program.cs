using ExchangeRates.Data;
using HtmlAgilityPack;
using ParseSite.Fin.ua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

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

            Console.ReadLine();
        }
    }
}
