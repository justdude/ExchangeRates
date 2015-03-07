using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using Data;

namespace ExchangeRates.Handlers
{
	public class PrivatHandler
	{
		public static List<KursData> GetExchangeRate(Bank bank)
		{
			try
			{
				if (bank == null || string.IsNullOrEmpty(bank.Url))
					return new List<KursData>();

				var request = WebRequest.Create(bank.Url);

				var resp = request.GetResponse();
				var stream = resp.GetResponseStream();

				if (stream == null)
					return null;

				StreamReader reader = new StreamReader(stream);
				string content = reader.ReadToEnd();

				var items = JsonConvert.DeserializeObject<List<KursData>>(content);
				
				return items;//responce.Data;
			}
			catch (Exception ex)
			{
				return null;
			}
		}


		//public static List<KursData> GetNalCursData()
		//{
		//	const string baseStr = @"https://api.privatbank.ua";
		//	const string str = @"p24api/pubinfo?json&exchange&coursid=5";

		//	var client = new RestClient(baseStr);

		//	var request = new RestRequest(str, RestSharp.Method.GET);
		//	request.RequestFormat = DataFormat.Json;

		//	var responce = client.Execute<List<KursData>>(request);

		//	return null;//responce.Data;
		//}
	}
}
