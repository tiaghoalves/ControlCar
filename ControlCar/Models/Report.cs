using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControlCar.Models
{
    public class Report
    {
        public int Id { get; set; }
        [Display(Name = "Início previsto")]
        public DateTime? ExpectedStartDate { get; set; }
        [Display(Name = "Final previsto")]
        public DateTime? ExpectedEndDate { get; set; }
        [Display(Name = "Início realizado")]
        public DateTime? StartDatePerformed { get; set; }
        [Display(Name = "Final realizado")]
        public DateTime? EndDatePerformed { get; set; }
        [Display(Name = "Km Final")]
        public double? EndKm { get; set; }
        [Display(Name = "Motorista")]
        public Driver Driver { get; set; }
        [Display(Name = "Veículo")]
        public Vehicle Vehicle { get; set; }
        [Display(Name = "Rota")]
        public Route Route { get; set; }
    }
}
