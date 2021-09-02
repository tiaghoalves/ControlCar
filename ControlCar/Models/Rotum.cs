using System;
using System.Collections.Generic;

#nullable disable

namespace ControlCar.Models
{
    public partial class Rotum
    {
        public Rotum()
        {
            Agendamentos = new HashSet<Agendamento>();
        }

        public int IdRota { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public double? KmPadrao { get; set; }

        public virtual ICollection<Agendamento> Agendamentos { get; set; }
    }
}
