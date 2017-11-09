using System;
using System.Collections.Generic;

namespace OOAD_Northwind.Models
{
    public partial class Units
    {
        public Units()
        {
            Quantities = new HashSet<Quantities>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Quantities> Quantities { get; set; }
    }
}
