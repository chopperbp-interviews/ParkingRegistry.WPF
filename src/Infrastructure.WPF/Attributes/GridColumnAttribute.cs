using System;
using System.ComponentModel;

namespace ParkingRegistry.Infrastructure.WPF.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GridColumnAttribute : Attribute
    {
        public GridColumnAttribute()
        {

        }
        public GridColumnAttribute(string displayName)
        {
            DisplayName = displayName;
        }
        public GridColumnAttribute(string displayName, ListSortDirection sortDirection)
        {
            DisplayName = displayName;
            SortDirection = sortDirection;
        }
        public ListSortDirection? SortDirection { get; set; }
        public string? DisplayName { get; set; }
        public int Order { get; set; } = -1;
        public bool Canceled { get; set;  } = false;
    }
}
