using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ControlCar.Models
{
    public partial class Driver
    {
        public Driver()
        {
            Scheduling = new HashSet<Scheduling>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDriver { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Name { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "CPF é obrigatório")]
        public string Cpf { get; set; }
        
        [Display(Name = "Data de validade CNH")]
        [Required(ErrorMessage = "Data de validade CNH é obrigatório")]
        public DateTime ExpirationDateCnh { get; set; }
        
        [Display(Name = "Cargo")]
        public string Office { get; set; }

        [Display(Name = "Endereço")]
        public string Address { get; set; }
        
        [Display(Name = "Celular")]
        public string Cellphone { get; set; }

        [Display(Name = "Tipo de motorista")]
        public string TypeDriver { get; set; }
        
        [Display(Name = "Data de nascimento")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Setor")]
        public string Sector { get; set; }
        
        [Display(Name = "RG")]
        [Required(ErrorMessage = "RG é obrigatório")]
        public decimal Rg { get; set; }

        public virtual ICollection<Scheduling> Scheduling { get; set; }
    }
}
