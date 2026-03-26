namespace DotnetApplication.Models
{
    public class PropertyItem
    {
        public string Name { get; set; } = string.Empty;
        public decimal AreaSqFt { get; set; }
        public decimal RatePerSqFt { get; set; }
        public decimal Amount { get; set; }
    }
}
