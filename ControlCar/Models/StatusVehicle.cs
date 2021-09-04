using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ControlCar.Models
{
    public partial class StatusVehicle
    {
        public StatusVehicle()
        {
            Vehicle = new HashSet<Vehicle>();
        }

        public int IdstatusVehicle { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
