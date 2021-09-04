using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ControlCar.Models
{
    public partial class VehicleMaintenance
    {
        public int IdVehicleMaintenance { get; set; }
        public int IdVehicle { get; set; }
        public int IdMaintenance { get; set; }
        public DateTime DateMaintenance { get; set; }

        public virtual Maintenance IdMaintenanceNavigation { get; set; }
        public virtual Vehicle IdVehicleNavigation { get; set; }
    }
}
