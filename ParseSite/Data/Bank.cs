using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
	[Serializable]
	public class Bank
	{
		[JsonProperty]
		public string Name { get; set; }
		[JsonProperty]
		public string Url { get; set; }

		public Bank(string name, string url)
		{
			Name = name;
			Url = url;
		}
		public Bank() { }
	}
}
