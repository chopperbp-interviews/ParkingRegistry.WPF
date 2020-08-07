using ParkingRegistry.WPF.ViewModels;
using System.Windows.Controls;

namespace ParkingRegistry.WPF.Views
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ParkingList : UserControl
    {
        public ParkingList(ParkingListViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
