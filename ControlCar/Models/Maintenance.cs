using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ControlCar.Models
{
    public partial class Maintenance
    {
        public Maintenance()
        {
            VehicleMaintenance = new HashSet<VehicleMaintenance>();
        }

        public int IdMaintenance { get; set; }
        public string Description { get; set; }
        public DateTime Frequency { get; set; }

        public virtual ICollection<VehicleMaintenance> VehicleMaintenance { get; set; }
    }
}
