using System;
using System.Collections.Generic;

namespace OOAD_Northwind.Models
{
    public partial class Territories
    {
        public string TerritoryId { get; set; }
        public string TerritoryDescription { get; set; }
        public int RegionId { get; set; }

        public Region Region { get; set; }
    }
}
