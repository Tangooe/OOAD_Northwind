using System;
using System.Collections.Generic;

namespace OOAD_Northwind.Models
{
    public partial class PartyTypes
    {
        public PartyTypes()
        {
            Parties = new HashSet<Parties>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; }

        public ICollection<Parties> Parties { get; set; }
    }
}
