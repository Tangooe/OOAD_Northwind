using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOAD_Northwind.Models;

namespace OOAD_Northwind.Test
{
    [TestClass]
    public class QuantityTests
    {
        private UnitConverter _unitConverter;
        private Units _sek;
        private Quantities _quantity;

        [TestInitialize]
        public void Initialize()
        {
            var optionsBuilder = new DbContextOptionsBuilder<NorthwindContext>();
            optionsBuilder.UseInMemoryDatabase("DefaultConnection");
            var context = new NorthwindContext(optionsBuilder.Options);
        
            var USD = new Units
            {
                Name = "USD"
            };
            var SEK = new Units
            {
                Name = "SEK"
            };

            context.ConversionRatios.Add(
                new ConversionRatio
                {
                    FromUnit = USD,
                    ToUnit = SEK,
                    Ratio = 8.40M
                });

            context.SaveChanges();

            _quantity = new Quantities
            {
                Amount = 100,
                Unit = USD
            };

            _sek = SEK;

            _unitConverter = new UnitConverter(context);
        }
        [TestMethod]
        public void USDtoSEK()
        {
            Assert.AreEqual(_unitConverter.Convert(_quantity, _sek).Amount, 840M);
        }
    }
}
