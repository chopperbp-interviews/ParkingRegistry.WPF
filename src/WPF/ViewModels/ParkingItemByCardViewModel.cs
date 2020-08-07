using ParkingRegistry.Infrastructure.WPF.Attributes;

namespace ParkingRegistry.WPF.ViewModels
{
    public class ParkingItemByCardViewModel : ParkingItemViewModel
    {
        [GridColumn("Partner")]
        public string CustomerName { get; set; } = default!;
        [GridColumn("Kártya")]
        public string PassNumber { get;  set; } = default!;
        [GridColumn("Kedvezmény")]
        public int Discount { get;  set; } = default!;
    }
}
