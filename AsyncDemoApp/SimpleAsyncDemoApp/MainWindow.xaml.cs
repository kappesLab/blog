using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows;




namespace SimpleAsyncDemoApp
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void SyncExecute_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AsyncExecute_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowWebSiteInfoData(WebSiteInfoDataModel infoData)
        {
            this.ResultTextBlock.Text += $"{ infoData.Url }: { infoData.Text.Length } caratteri scaricati.{ Environment.NewLine }";
        }


    }
}
