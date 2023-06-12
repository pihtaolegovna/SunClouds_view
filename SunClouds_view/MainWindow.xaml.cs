﻿using System;
using System.Windows;
using System.Windows.Input;

namespace SunClouds_view
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left)
			{
				DragMove();
			}
		}
		private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}
		// Minimize
		private void CommandBinding_Executed_Minimize(object sender, ExecutedRoutedEventArgs e)
		{
			SystemCommands.MinimizeWindow(this);
		}
		// Maximize
		private void CommandBinding_Executed_Maximize(object sender, ExecutedRoutedEventArgs e)
		{
			SystemCommands.MaximizeWindow(this);
			RestoreButton.Visibility = Visibility.Visible;
			MaximizeButton.Visibility = Visibility.Collapsed;
		}
		// Restore
		private void CommandBinding_Executed_Restore(object sender, ExecutedRoutedEventArgs e)
		{
			SystemCommands.RestoreWindow(this);
			RestoreButton.Visibility = Visibility.Collapsed;
			MaximizeButton.Visibility = Visibility.Visible;
		}
		// Для закрытия
		private void CommandBinding_Executed_Close(object sender, ExecutedRoutedEventArgs e)
		{
			SystemCommands.CloseWindow(this);
		}
		// Отвечает за смену кнопки во весь экран/Вид в окне
		private void MainWindowStateChangeRaised(object sender, EventArgs e)
		{
			if (!(WindowState == WindowState.Maximized))
			{
				RestoreButton.Visibility = Visibility.Visible;
				MaximizeButton.Visibility = Visibility.Collapsed;
			}
			else
			{
				RestoreButton.Visibility = Visibility.Collapsed;
				MaximizeButton.Visibility = Visibility.Visible;
			}
		}

		private void WeatherPageButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Source = new Uri("Settings.xaml", UriKind.Relative);
		}

		private void SettingsPageButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Source = new Uri("WeatherData.xaml", UriKind.Relative);
		}
	}
}
