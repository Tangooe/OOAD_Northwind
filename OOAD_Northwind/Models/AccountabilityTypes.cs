using System;
using System.Collections.Generic;

namespace OOAD_Northwind.Models
{
    public class AccountabilityTypes
    {
        public AccountabilityTypes()
        {
            Accountabilities = new HashSet<Accountabilities>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; }

        public ICollection<Accountabilities> Accountabilities { get; set; }
    }
}
