using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Logging;
using ParkingRegistry.WPF.Views;
using System;
using System.Windows;

namespace ParkingRegistry.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(ParkingList parkingList, ISnackbarMessageQueue messageQueue)
        {
            InitializeComponent();
            DataContext = this;
            ContentControl.Content =  parkingList;
            MessageQueue = messageQueue;
        }
        public ISnackbarMessageQueue MessageQueue { get; }
    }
}
