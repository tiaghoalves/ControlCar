using System;
using System.Collections.Generic;

#nullable disable

namespace ControlCar.Models
{
    public partial class Agendamento
    {
        public int IdAgendamento { get; set; }
        public DateTime DataInicialPrevista { get; set; }
        public DateTime DataFinalPrevista { get; set; }
        public int? IdRota { get; set; }
        public int? IdVeiculo { get; set; }
        public int? IdMotorista { get; set; }
        public DateTime? DataInicialRealizada { get; set; }
        public DateTime? DataFinalRealizada { get; set; }
        public double? KmFinal { get; set; }
        public int? IdStatusAgendamento { get; set; }
        public int? IdAutenticacao { get; set; }

        public virtual Autenticacao IdAutenticacaoNavigation { get; set; }
        public virtual Motoristum IdMotoristaNavigation { get; set; }
        public virtual Rotum IdRotaNavigation { get; set; }
        public virtual StatusAgendamento IdStatusAgendamentoNavigation { get; set; }
        public virtual Veiculo IdVeiculoNavigation { get; set; }
    }
}
