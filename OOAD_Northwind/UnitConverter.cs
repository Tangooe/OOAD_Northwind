using OOAD_Northwind.Models;
using System.Linq;

namespace OOAD_Northwind
{
    public class UnitConverter
    {
        private readonly NorthwindContext _rep;
        public UnitConverter(NorthwindContext ratioRep)
        {
            _rep = ratioRep;
        }
        public Quantities Convert(Quantities from, Units toUnit)
        {
            var conversionRatio = _rep.ConversionRatios.FirstOrDefault(x => x.FromUnitId == from.Id && x.ToUnitId == toUnit.Id);

            if (conversionRatio.Equals(null))
                return null;

            return new Quantities
            {
                Id = from.Id,
                Amount = conversionRatio.Ratio * from.Amount,
                Unit = toUnit
            };
        }
    }
}