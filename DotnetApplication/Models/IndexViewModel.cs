using System.Collections.Generic;
using System.Linq;

namespace DotnetApplication.Models
{
    public class IndexViewModel
    {
        public List<OptionItem> Options { get; set; } = new List<OptionItem>();
        public int SelectedId { get; set; }
        public OptionItem? SelectedOption => Options.FirstOrDefault(o => o.Id == SelectedId);

        // Selected property name from the table - used to show full details on demand
        public string SelectedPropertyName { get; set; } = string.Empty;
        public PropertyItem? SelectedProperty => Items.FirstOrDefault(i => i.Name == SelectedPropertyName);

        // Edit mode: which property is being edited and the new rate value
        public string EditPropertyName { get; set; } = string.Empty;
        public decimal NewRate { get; set; }

        // Property items for the rate/area table
        public List<PropertyItem> Items { get; set; } = new List<PropertyItem>();

        public decimal TotalArea => Items.Sum(i => i.AreaSqFt);
        public decimal TotalAmount => Items.Sum(i => i.Amount);
        public decimal OverallRate => TotalArea == 0 ? 0 : Decimal.Round(TotalAmount / TotalArea, 2);
    }
}
