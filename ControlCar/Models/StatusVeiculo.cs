using System;
using System.Collections.Generic;

#nullable disable

namespace ControlCar.Models
{
    public partial class StatusVeiculo
    {
        public StatusVeiculo()
        {
            Veiculos = new HashSet<Veiculo>();
        }

        public int IdstatusVeiculo { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Veiculo> Veiculos { get; set; }
    }
}
