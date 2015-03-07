using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Data
{

	[Serializable]
	public class BankData
	{
		[JsonProperty]
		public Bank bank { get; set;}

		[JsonProperty]
		public KursData kurs { get; set; }
	}
}
