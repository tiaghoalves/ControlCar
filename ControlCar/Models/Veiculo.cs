using System;
using System.Collections.Generic;

#nullable disable

namespace ControlCar.Models
{
    public partial class Veiculo
    {
        public Veiculo()
        {
            Agendamentos = new HashSet<Agendamento>();
            VeiculoManutencaos = new HashSet<VeiculoManutencao>();
        }

        public int IdVeiculo { get; set; }
        public string Modelo { get; set; }
        public double Km { get; set; }
        public string Placa { get; set; }
        public string Tipo { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
        public DateTime Ano { get; set; }
        public decimal Renavam { get; set; }
        public decimal Chassi { get; set; }
        public int? IdStatusVeiculo { get; set; }
        public string Observacao { get; set; }

        public virtual StatusVeiculo IdStatusVeiculoNavigation { get; set; }
        public virtual ICollection<Agendamento> Agendamentos { get; set; }
        public virtual ICollection<VeiculoManutencao> VeiculoManutencaos { get; set; }
    }
}
