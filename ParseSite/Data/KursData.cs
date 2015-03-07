using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public enum StateType
    { 
        None,
        Raise,
        RaiseDown
    }

	[Serializable]
	public class KursData :	IComparable<KursData>
	{
		[JsonProperty]
		public string Ccy { get; set; } 	/*Код валюты (справочник кодов валют: https://ru.wikipedia.org/wiki/Коды_валют)*/
		[JsonProperty]
		public string Base_ccy { get; set; }	//Код национальной валюты
		[JsonProperty]
		public string Buy { get; set; }	//Курс покупки
		[JsonProperty]
		public string Sale { get; set; }
    public DateTime EntryDate { get; set; }
		[JsonProperty]
    public string Date { get; set; }
		[JsonProperty]
    public StateType GrowthBuy { get; set; }
		[JsonProperty]
    public StateType GrowthSale { get; set; }

		public KursData()
		{
			EntryDate = DateTime.Now;
		}


		#region IComparable<KursData> Members

		public int CompareTo(KursData other)
		{
			return Ccy.CompareTo(other);
		}

		#endregion
	}
}

