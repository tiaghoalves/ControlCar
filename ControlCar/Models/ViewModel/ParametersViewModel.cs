using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlCar.Models.ViewModel
{
    public class ParametersViewModel
    {
        public DateTime InitialDate { get; set; }
        public DateTime EndDate { get; set; }
        public int IdDriver { get; set; }
        public List<Driver> Drivers { get; set; }
        public int IdVehicle { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public int IdRoute { get; set; }
        public List<Route> Routes { get; set; }
        public decimal InitKmVehicle { get; set; }
        public decimal EndKmVehicle { get; set; }
        
    }
}
