using System;
using System.Collections.Generic;

#nullable disable

namespace ControlCar.Models
{
    public partial class Motoristum
    {
        public Motoristum()
        {
            Agendamentos = new HashSet<Agendamento>();
        }

        public int IdMotorista { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataVencimentoCnh { get; set; }
        public string Cargo { get; set; }
        public string Endereco { get; set; }
        public string Celular { get; set; }
        public string TipoMotorista { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Setor { get; set; }
        public decimal Rg { get; set; }

        public virtual ICollection<Agendamento> Agendamentos { get; set; }
    }
}
