using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControlCar.Models.ViewModel
{
    public class DriverViewModel
    {
        public int IdDriver { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime ExpirationDateCnh { get; set; }
        public string Office { get; set; }
        public string Address { get; set; }
        public string Cellphone { get; set; }
        public string TypeDriver { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Sector { get; set; }
        public decimal Rg { get; set; }
    }
}
