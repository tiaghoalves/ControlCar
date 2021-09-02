using System;
using System.Collections.Generic;

#nullable disable

namespace ControlCar.Models
{
    public partial class Manutencao
    {
        public Manutencao()
        {
            VeiculoManutencaos = new HashSet<VeiculoManutencao>();
        }

        public int IdManutencao { get; set; }
        public string Descricao { get; set; }
        public DateTime Periodicidade { get; set; }

        public virtual ICollection<VeiculoManutencao> VeiculoManutencaos { get; set; }
    }
}
