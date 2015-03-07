using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using Data;

namespace ExchangeRates.ViewModel
{
	public class BankViewModel : ViewModelBase
	{
		public Bank BankData { get; private set; }

		public string Name 
		{ get
			{
				return BankData.Name;
			}
			set
			{
				if (value == BankData.Name)
					return;

				BankData.Name = value;

				RaisePropertyChanged("Name");
			}
		}

		public string Url
		{
			get
			{
				return BankData.Url;
			}
			set
			{
				if (value == BankData.Url)
					return;

				BankData.Url = value;

				RaisePropertyChanged("Url");
			}
		}
		
		public BankViewModel(Bank bank)
		{
			BankData = bank;
		}

		public BankViewModel(string name, string url)
		{
			BankData = new Bank(name, url);
		}

	}
}
