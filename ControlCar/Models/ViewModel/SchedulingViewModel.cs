using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControlCar.Models.ViewModel
{
    public class SchedulingViewModel
    {
        [Display(Name = "Início previsto")]
        public DateTime ExpectedStartDate { get; set; }
        [Display(Name = "Final previsto")]
        public DateTime ExpectedEndDate { get; set; }
        [Display(Name = "Motorista")]
        public int IdDriver { get; set; }
        public List<Driver> Drivers { get; set; }
        [Display(Name = "Veículo")]
        public int IdVehicle { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        [Display(Name = "Rota")]
        public int IdRoute { get; set; }
        public List<Route> Routes { get; set; }
    }
}
