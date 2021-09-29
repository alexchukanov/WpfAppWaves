﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppWaves
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		MarketViewModel vm = new MarketViewModel();

		public MainWindow()
		{
			InitializeComponent();
			DataContext = vm;

			Loaded += MainWindow_Loaded;
		}

		private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			await vm.LoadMarketData();
			cbRange.SelectedIndex = 0;
			cbStep.SelectedIndex = 0;
		}

		private async void ButtonLoad_Click(object sender, RoutedEventArgs e)
		{
			vm.ValidRange = cbRange.SelectedValue.ToString();
			vm.StepInterval = cbStep.SelectedValue.ToString();
			await vm.LoadMarketData();
		}
	}
}