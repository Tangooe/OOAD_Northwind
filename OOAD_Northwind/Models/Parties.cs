using System;
using System.Collections.Generic;

namespace OOAD_Northwind.Models
{
    public partial class Parties
    {
        public Parties()
        {
            AccountabilitiesPartyANavigation = new HashSet<Accountabilities>();
            AccountabilitiesPartyBNavigation = new HashSet<Accountabilities>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int? Type { get; set; }

        public PartyTypes TypeNavigation { get; set; }
        public ICollection<Accountabilities> AccountabilitiesPartyANavigation { get; set; }
        public ICollection<Accountabilities> AccountabilitiesPartyBNavigation { get; set; }
    }
}
