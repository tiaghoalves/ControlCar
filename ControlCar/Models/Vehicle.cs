using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "Modelo é obrigatório")]
        public string Model { get; set; }

        [Display(Name = "KM")]
        [Required(ErrorMessage = "KM é obrigatório")]
        public double Km { get; set; }

        [Display(Name = "Placa")]
        public string Board { get; set; }

        [Display(Name = "Tipo")]
        public string Type { get; set; }

        [Display(Name = "Marca")]
        public string Brand { get; set; }

        [Display(Name = "Cor")]
        public string Color { get; set; }

        [Display(Name = "Ano")]
        [Required(ErrorMessage = "Ano é obrigatório")]
        public DateTime Year { get; set; }

        [Display(Name = "Renavam")]
        [Required(ErrorMessage = "Número do Renavam é obrigatório")]
        public decimal Renavam { get; set; }

        [Display(Name = "Chassi")]
        [Required(ErrorMessage = "Número do chassi é obrigatório")]
        public decimal Chassi { get; set; }

        [Display(Name = "Status Veículo")]
        public int? IdStatusVehicle { get; set; }

        [Display(Name = "Observação")]
        public string Observation { get; set; }

        [Display(Name = "Status")]
        public virtual StatusVehicle IdStatusVehicleNavigation { get; set; }
        public virtual ICollection<Scheduling> Scheduling { get; set; }
        public virtual ICollection<VehicleMaintenance> VehicleMaintenance { get; set; }
    }
}
