using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControlCar.Models.ViewModel
{
    public class ParametersViewModel
    {
        [Display(Name = "Data inicial")]
        public DateTime InitialDate { get; set; }
        [Display(Name = "Data final")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Motorista")]
        public int IdDriver { get; set; }
        public List<Driver> Drivers { get; set; }
        [Display(Name = "Veículo")]
        public int IdVehicle { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        [Display(Name = "Rota")]
        public int IdRoute { get; set; }
        public List<Route> Routes { get; set; }
        [Display(Name = "Km inicial do veículo")]
        public decimal InitKmVehicle { get; set; }
        [Display(Name = "Km final do veículo")]
        public decimal EndKmVehicle { get; set; }
        
    }
}
