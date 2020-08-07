using ParkingRegistry.Infrastructure.WPF.Attributes;
using ParkingRegistry.Infrastructure.WPF.ViewModels;
using System;
using System.ComponentModel;

namespace ParkingRegistry.WPF.ViewModels
{
    public class ParkingItemViewModel : ViewModelBase
    {
        [GridColumn(Canceled=true)]
        public int Id { get; set; }
        [GridColumn("Rendszám")]
        public string NumberPlate { get; set; } = default!;
        [GridColumn("Parkolás kezdete",  ListSortDirection.Ascending)]
        public DateTimeOffset StartDate { get;  set; } = default!;
        [GridColumn("Parkolás Vége")]
        public DateTimeOffset? EndDate { get;  set; } = default!;
    }
}
