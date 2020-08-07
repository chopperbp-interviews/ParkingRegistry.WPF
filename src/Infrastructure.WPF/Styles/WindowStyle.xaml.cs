using System.Windows;

namespace ParkingRegistry.Infrastructure.WPF.Styles
{
    public partial class WindowStyle : ResourceDictionary
    {
        public WindowStyle()
        {
            InitializeComponent();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            var window = (Window)((FrameworkElement)sender).TemplatedParent;
            window.Close();
        }
    }
}
