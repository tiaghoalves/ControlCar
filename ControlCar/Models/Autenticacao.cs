using System;
using System.Collections.Generic;

#nullable disable

namespace ControlCar.Models
{
    public partial class Autenticacao
    {
        public Autenticacao()
        {
            Agendamentos = new HashSet<Agendamento>();
        }

        public int IdAutenticacao { get; set; }
        public string Usuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<Agendamento> Agendamentos { get; set; }
    }
}
