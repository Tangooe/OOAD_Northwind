using System;

namespace OOAD_Northwind.Models
{
    public class Accountabilities
    {
        public int Id { get; set; }
        public int PartyA { get; set; }
        public int PartyB { get; set; }
        public int Type { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }

        public Parties PartyANavigation { get; set; }
        public Parties PartyBNavigation { get; set; }
        public AccountabilityTypes TypeNavigation { get; set; }
    }
}
