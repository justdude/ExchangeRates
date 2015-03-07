using System;
using System.Windows;
using System.Threading;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace ExchangeRates.ViewHelpers
{
    public static class MenuItemHelper
    {
			//						ExchangeRates:MenuItemHelper.SelectedItemHandle="{Binding SelectedItem,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}"

			public static readonly DependencyProperty IsExecuteProperty = DependencyProperty.RegisterAttached("IsExecute", typeof(bool), typeof(MenuItemHelper),
			 new PropertyMetadata(
				new PropertyChangedCallback(OnSelectionChangedIsUse)));

			private static void OnSelectionChangedIsUse(DependencyObject d, DependencyPropertyChangedEventArgs e)
			{				
				var menuItem = d as MenuItem;

				if (menuItem == null)
					return;

				var sub = menuItem.ContextMenu;
				menuItem.Click += menuItem_Click;
				//menuItem.com += menuItem_Checked;
			}

			static void menuItem_Click(object sender, RoutedEventArgs e)
			{
				var menuItem = sender as MenuItem;

				var obj = sender as DependencyObject;
				var command = GetClickCommand(obj);

				var newTarget = e.OriginalSource as MenuItem;

				if (newTarget == null)
					return;

				command.Execute(newTarget.Header);
			}

			static void menuItem_Checked(object sender, RoutedEventArgs e)
			{
				//SetSelectedItemHandle(SelectedItemHandleProperty, sender);
			}


			public static bool GetIsExecuteProperty(DependencyObject obj)
			{
				return (bool)obj.GetValue(IsExecuteProperty);
			}

			public static void SetIsExecute(DependencyObject obj, bool value)
			{
				obj.SetValue(IsExecuteProperty, value);
			}


			public static readonly DependencyProperty TheCommandToRunProperty =
		DependencyProperty.RegisterAttached("TheCommandToRun",
				typeof(ICommand),
				typeof(MenuItemHelper),
				new FrameworkPropertyMetadata((ICommand)null));

			public static object Param = null;

			/// <summary>
			/// Gets the TheCommandToRun property.  
			/// </summary>
			public static ICommand GetTheCommandToRun(DependencyObject d)
			{
				return (ICommand)d.GetValue(TheCommandToRunProperty);
			}

			/// <summary>
			/// Sets the TheCommandToRun property.  
			/// </summary>
			public static void SetTheCommandToRun(DependencyObject d, ICommand value)
			{
				d.SetValue(TheCommandToRunProperty, value);
			}



			public static readonly DependencyProperty ClickCommandProperty =
					DependencyProperty.RegisterAttached("ClickCommand", 
					typeof(ICommand), 
					typeof(MenuItemHelper),
					new FrameworkPropertyMetadata((ICommand)null));

			public static ICommand GetClickCommand(DependencyObject obj)
			{
				return (ICommand)obj.GetValue(ClickCommandProperty);
			}

			public static void SetClickCommand(DependencyObject obj, 
				ICommand value)
			{
				obj.SetValue(ClickCommandProperty, value);
			}


			//public static readonly DependencyProperty SelectedItemHandleProperty = DependencyProperty.RegisterAttached("SelectedClickCommand", typeof(ICommand), typeof(MenuItemHelper), 
			//	new PropertyMetadata(new UIPropertyMetadata(null, OnSelectionChanged)));

			////public object SelectedItemHandle
			////{
			////	get
			////	{
			////		return GetSelectedItemHandle();
			////	}
			////	set
			////	{
			////		SetSelectedItemHandle(value);
			////	}
			////}

			//public static object GetSelectedItemHandle(DependencyObject obj)
			//{
			//	return (ICommand)obj.GetValue(SelectedItemHandleProperty);
			//}

			//public static void SetSelectedItemHandle(DependencyObject obj, object value)
			//{
			//	obj.SetValue(SelectedItemHandleProperty, value);
			//}



			//private static void OnSelectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
			//{
			//	var menuItem = d as MenuItem;
				
			//	if (menuItem == null)
			//		return;
			//}
    }
}