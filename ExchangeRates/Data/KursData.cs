using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExchangeRates.Data
{
	public class KursData
	{
		[JsonProperty]
		public string Ccy {get; set;} 	/*Код валюты (справочник кодов валют: https://ru.wikipedia.org/wiki/Коды_валют)*/

		[JsonProperty]
		public string Base_ccy {get; set;}	//Код национальной валюты

		[JsonProperty]
		public string Buy {get; set;}	//Курс покупки

		[JsonProperty]
		public string Sale { get; set; }

		public DateTime EntryDate;

		public KursData()
		{
			EntryDate = DateTime.Now;
		}

	}
}

