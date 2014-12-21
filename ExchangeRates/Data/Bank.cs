using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExchangeRates.Data
{
	public class Bank
	{
		public string Name { get; set; }
		public string Url { get; set; }

		public Bank(string name, string url)
		{
			Name = name;
			Url = url;
		}
	}
}
