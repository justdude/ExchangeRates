using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExchangeRates
{
	public class CNotifyIcon
	{
		public NotifyIcon Icon { get; private set; }

		public static CNotifyIcon Instance { get; private set; }

		static CNotifyIcon()
		{
			Instance = new CNotifyIcon();
		}
		
		private CNotifyIcon() 
		{
			Icon = new NotifyIcon();


    }

		public string IconPath { get; set; }
		public string ToolTipText 
		{ 
			get
			{
				return Icon.BalloonTipText;
			} 
			set
			{
				Icon.BalloonTipText = value;
			}
		}

		public bool IsVisible
		{
			get
			{
				return Icon.Visible;
			}
			set
			{
				Icon.Visible = value;
			}
		}

		public void Init()
		{
			string str = @"D:\icon.ico";

			LoadIcon(str);
			IsVisible = true;
		}

		public void LoadIcon(string path)
		{
			try
			{
				Icon.Icon = new System.Drawing.Icon(path);
			}
			catch (Exception ex)
			{

			}
		}



	}
}
