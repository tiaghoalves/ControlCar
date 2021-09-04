using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ControlCar.Models
{
    public partial class StatusScheduling
    {
        public StatusScheduling()
        {
            Scheduling = new HashSet<Scheduling>();
        }

        public int IdstatusScheduling { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Scheduling> Scheduling { get; set; }
    }
}
