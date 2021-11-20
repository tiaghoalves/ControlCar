using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControlCar.Models.ViewModel
{
    public class SchedulingEditViewModel
    {
        public int IdScheduling { get; set; }
        public DateTime ExpectedStartDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        [Display(Name = "Motorista")]
        public int? IdDriver { get; set; }
        public List<Driver> Drivers { get; set; }
        [Display(Name = "Veículo")]
        public int? IdVehicle { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        [Display(Name = "Rota")]
        public int? IdRoute { get; set; }
        public List<Route> Routes { get; set; }
        public int? IdStatusScheduling { get; set; }
        public List<StatusScheduling> Statuses { get; set; }
        public DateTime? StartDatePerformed { get; set; }
        public DateTime? EndDatePerformed { get; set; }
        public double? EndKm { get; set; }
    }
}
