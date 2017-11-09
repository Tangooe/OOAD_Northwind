namespace OOAD_Northwind.Models
{
    public class ConversionRatio
    {
        public int ConversionRatioId { get; set; }
        public int FromUnitId { get; set; }
        public Units FromUnit { get; set; }
        public int ToUnitId { get; set; }
        public Units ToUnit { get; set; }
        public decimal Ratio { get; set; }
    }
}
