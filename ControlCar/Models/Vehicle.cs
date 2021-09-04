using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ControlCar.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Scheduling = new HashSet<Scheduling>();
            VehicleMaintenance = new HashSet<VehicleMaintenance>();
        }

        public int IdVehicle { get; set; }
        public string Model { get; set; }
        public double Km { get; set; }
        public string Board { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public DateTime Year { get; set; }
        public decimal Renavam { get; set; }
        public decimal Chassi { get; set; }
        public int? IdStatusVehicle { get; set; }
        public string Observation { get; set; }

        public virtual StatusVehicle IdStatusVehicleNavigation { get; set; }
        public virtual ICollection<Scheduling> Scheduling { get; set; }
        public virtual ICollection<VehicleMaintenance> VehicleMaintenance { get; set; }
    }
}
