using System;
using System.Collections.Generic;

namespace OOAD_Northwind.Models
{
    public class OrderDetails
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int QuantityId { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public Orders Order { get; set; }
        public Products Product { get; set; }
        public Quantities QuantityNavigation { get; set; }
    }
}
