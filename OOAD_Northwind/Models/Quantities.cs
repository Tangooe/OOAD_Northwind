using System;
using System.Collections.Generic;

namespace OOAD_Northwind.Models
{
    public partial class Quantities
    {
        public Quantities()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public decimal? Amount { get; set; }
        public int? UnitId { get; set; }

        public Units Unit { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
