using System;
using System.Collections.Generic;

#nullable disable

namespace ControlCar.Models
{
    public partial class VeiculoManutencao
    {
        public int IdVeiculoManutencao { get; set; }
        public int IdVeiculo { get; set; }
        public int IdManutencao { get; set; }
        public DateTime DataManutencao { get; set; }

        public virtual Manutencao IdManutencaoNavigation { get; set; }
        public virtual Veiculo IdVeiculoNavigation { get; set; }
    }
}
