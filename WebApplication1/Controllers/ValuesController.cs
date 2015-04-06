using Data;
using Newtonsoft.Json;
using ParseSite.Fin.ua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
	public class ValuesController : ApiController
	{

		#region testing
		// GET api/values
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/values/5
		public string Get(int id)
		{
			return "value";
		}

		// POST api/values
		public void Post([FromBody]string value)
		{
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
		}
		#endregion

		private const string SITE = @"http://finance.i.ua/";
    private const string USD = @"usd/";
    private const string EUR = @"eur/";
    private const string RUB = @"rub/";

		public string GetExchangeRates(string currency)
		{ 
			string target = string.Empty;

			switch (currency)
			{
				case "usd":
					target = USD;
					break;
				case "eur":
					target = EUR;
					break;
				case "rub":
					target = RUB;
					break;
				default:
					return string.Empty;
			}

			var cours = CParser.GetKursesFromFinUA(SITE, target);
			var arr = cours.Select( (b, d)=>{ return new BankData() {bank=b.Key, kurs=b.Value}; }).ToArray();

			string res = JsonConvert.SerializeObject(arr, Formatting.None,new JsonSerializerSettings());
			
			return res;
		}

	}
}
