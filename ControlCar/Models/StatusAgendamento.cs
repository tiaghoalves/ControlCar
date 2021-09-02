using System;
using System.Collections.Generic;

#nullable disable

namespace ControlCar.Models
{
    public partial class StatusAgendamento
    {
        public StatusAgendamento()
        {
            Agendamentos = new HashSet<Agendamento>();
        }

        public int IdstatusAgendamento { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Agendamento> Agendamentos { get; set; }
    }
}
