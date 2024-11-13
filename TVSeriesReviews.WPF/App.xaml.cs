﻿using System.Configuration;
using System.Data;
using System.Windows;
using TVSeriesReviews.WPF.ViewModels;

namespace TVSeriesReviews.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel()
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}