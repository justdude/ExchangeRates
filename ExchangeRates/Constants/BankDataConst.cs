using ExchangeRates.Data;
using ExchangeRates.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExchangeRates.Constants
{

	public class BankDataConst
	{
		public const string Privat_Nal = "Наличный курс Приватбанка (в отделениях)";
		public const string Privat_BezNal = "Безналичный курс Приватбанка (конвертация по картам, Приват24, пополнение вкладов)";

		public const string NBU = "Курсы валют НБУ";
		public const string CBRF = "Курсы валют ЦБ РФ";


		public static List<BankViewModel> Banks = new List<BankViewModel>()
		{
			new BankViewModel(Privat_Nal, @"https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=5"),

			new BankViewModel(Privat_BezNal, @"https://api.privatbank.ua/p24api/pubinfo?exchange&json&coursid=11"),

			new BankViewModel(NBU, @"https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=3"),

			new BankViewModel(CBRF, "https://privat24.privatbank.ua/p24/accountorder?oper=prp&PUREXML&apicour&country=ru")
		};
	}
}
