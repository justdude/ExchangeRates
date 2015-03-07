using Data;
using ExchangeRates.Handlers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ExchangeRates.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
			private string mvSourceName;
			private BankViewModel mvCurrentBank;

        public MainViewModel()
        {
					CurrentBank = Banks[0];
					ExchangeRate = new ObservableCollection<KursData>();
					Update();
        }

				public ICommand ShowWindowCommand
				{
					get
					{
						return new RelayCommand(
							() =>
							{
								Application.Current.MainWindow = new MainWindow();
								Application.Current.MainWindow.Show();
							},
							() => Application.Current.MainWindow == null
						);
					}
				}

				/// <summary>
				/// Hides the main window. This command is only enabled if a window is open.
				/// </summary>
				public ICommand HideWindowCommand
				{
					get
					{
						return new RelayCommand(
							() => Application.Current.MainWindow.Close(),
							() => Application.Current.MainWindow != null
						);
					}
				}

				/// <summary>
				/// Shuts down the application.
				/// </summary>
				public ICommand ExitApplicationCommand
				{
					get
					{
						return new RelayCommand (() => Application.Current.Shutdown());
					}
				}

				public ICommand ChangeBank
				{
					get
					{
						if (mvChangeBank == null)
							mvChangeBank = new RelayCommand<string>((p) =>
							{
								if (string.IsNullOrEmpty(p))
									return;

								var finded = Banks.Find(t => t.Name == p);
								if (finded == null)
									return;
									CurrentBank = finded;

								Update();
							});

						return mvChangeBank;
					}
				}

				public ICommand About
				{
					get
					{
						return new RelayCommand(() =>
						{
							System.Diagnostics.Process.Start("http://vk.com/dude_just_dude");
						});
					}
				}

				public List<BankViewModel> Banks
				{
					get
					{
						return Constants.BankDataConst.Banks;
					}
				}

				public BankViewModel CurrentBank
				{
					get
					{
						return mvCurrentBank;
					}
					set
					{
						mvCurrentBank = value;
						RaisePropertyChanged("CurrentBank");
					}
				}

				public object SelectedItem
				{
					get
					{
						return mvSelectedItem;
					}
					set
					{
						mvSelectedItem = value;
						RaisePropertyChanged("SelectedItem");
					}
				}

				public ObservableCollection<KursData> ExchangeRate { get; set; }
				public string LastUpdateTime
				{
					get
					{
						var timeSpan = (updateTime - DateTime.Now);
						return timeSpan.Seconds.ToString();
					}
				}

				public DateTime updateTime;
				private object mvSelectedItem;
				private RelayCommand<string> mvChangeBank;
				
				public void Update()
				{
					IsLoading = true;

					var exchangeRate = PrivatHandler.GetExchangeRate(CurrentBank.BankData);

					ExchangeRate.Clear();

					if (exchangeRate == null)
						return;

					foreach(var item in exchangeRate)
					{
						ExchangeRate.Add(item);
					}

					updateTime = DateTime.Now;
					IsLoading = false;
				}

				private void OnTimerTick()
				{

				}


				public bool IsLoading { get; set; }
		}
}