using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ControlCar.Models
{
    public partial class Driver
    {
        public Driver()
        {
            Scheduling = new HashSet<Scheduling>();
        }

        public int IdDriver { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime ExpirationDateCnh { get; set; }
        public string Office { get; set; }
        public string Address { get; set; }
        public string Cellphone { get; set; }
        public string TypeDriver { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Sector { get; set; }
        public decimal Rg { get; set; }

        public virtual ICollection<Scheduling> Scheduling { get; set; }
    }
}
