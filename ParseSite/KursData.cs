using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExchangeRates.Data
{
    public enum StateType
    { 
        None,
        Raise,
        RaiseDown
    }

	public class KursData
	{
		public string Ccy {get; set;} 	/*Код валюты (справочник кодов валют: https://ru.wikipedia.org/wiki/Коды_валют)*/

		public string Base_ccy {get; set;}	//Код национальной валюты

		public string Buy {get; set;}	//Курс покупки

		public string Sale { get; set; }
        
        public DateTime EntryDate { get; set; }
        
        public string Date { get; set; }

        public StateType GrowthBuy { get; set; }
        public StateType GrowthSale { get; set; }

		public KursData()
		{
			EntryDate = DateTime.Now;
		}

	}
}

