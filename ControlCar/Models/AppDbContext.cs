using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ControlCar.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agendamento> Agendamentos { get; set; }
        public virtual DbSet<Autenticacao> Autenticacaos { get; set; }
        public virtual DbSet<Manutencao> Manutencaos { get; set; }
        public virtual DbSet<Motoristum> Motorista { get; set; }
        public virtual DbSet<Rotum> Rota { get; set; }
        public virtual DbSet<StatusAgendamento> StatusAgendamentos { get; set; }
        public virtual DbSet<StatusVeiculo> StatusVeiculos { get; set; }
        public virtual DbSet<Veiculo> Veiculos { get; set; }
        public virtual DbSet<VeiculoManutencao> VeiculoManutencaos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-HSB3HRH\\SQLEXPRESS;Initial Catalog=ControlCar;Integrated Security=True;Pooling=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Agendamento>(entity =>
            {
                entity.HasKey(e => e.IdAgendamento)
                    .HasName("pk_agendamento")
                    .IsClustered(false);

                entity.ToTable("Agendamento");

                entity.Property(e => e.IdAgendamento)
                    .ValueGeneratedNever()
                    .HasComment("Identificador do Agendamento (PK)");

                entity.Property(e => e.DataFinalPrevista)
                    .HasColumnType("datetime")
                    .HasComment("Data Final Prevista do Agendamento");

                entity.Property(e => e.DataFinalRealizada)
                    .HasColumnType("datetime")
                    .HasComment("Data Final do Agendamento Realizado");

                entity.Property(e => e.DataInicialPrevista)
                    .HasColumnType("datetime")
                    .HasComment("Data Inicial Prevista do Agendamento");

                entity.Property(e => e.DataInicialRealizada)
                    .HasColumnType("datetime")
                    .HasComment("Data Inicial do Agendamento Realizado");

                entity.Property(e => e.IdAutenticacao).HasComment("Identificação da autenticação (FK AUTENTICACAO)");

                entity.Property(e => e.IdMotorista).HasComment("Identificação do motorista (FK MOTORISTAS)");

                entity.Property(e => e.IdRota).HasComment("Identificação da rota (FK ROTAS)");

                entity.Property(e => e.IdStatusAgendamento).HasComment("Identificação de status, finalizada em (FK STATUSAGENDAMENTO)");

                entity.Property(e => e.IdVeiculo).HasComment("Identificação do veículo (FK VEICULOS)");

                entity.Property(e => e.KmFinal).HasComment("Quilometragem percorrida");

                entity.HasOne(d => d.IdAutenticacaoNavigation)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.IdAutenticacao)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_agendamento_autenticacao");

                entity.HasOne(d => d.IdMotoristaNavigation)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.IdMotorista)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_agendamento_motorista");

                entity.HasOne(d => d.IdRotaNavigation)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.IdRota)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_agendamento_rota");

                entity.HasOne(d => d.IdStatusAgendamentoNavigation)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.IdStatusAgendamento)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_agendamento_status_agendamento");

                entity.HasOne(d => d.IdVeiculoNavigation)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.IdVeiculo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_agendamento_veiculo");
            });

            modelBuilder.Entity<Autenticacao>(entity =>
            {
                entity.HasKey(e => e.IdAutenticacao)
                    .HasName("pk_autenticacao")
                    .IsClustered(false);

                entity.ToTable("Autenticacao");

                entity.Property(e => e.IdAutenticacao)
                    .ValueGeneratedNever()
                    .HasComment("Identificador da  autenticação (PK)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Endereço de e-mail do usuário administrador");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Senha do usuário administrador");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Nome do usuário Administrador");
            });

            modelBuilder.Entity<Manutencao>(entity =>
            {
                entity.HasKey(e => e.IdManutencao)
                    .HasName("pk_manutencao")
                    .IsClustered(false);

                entity.ToTable("Manutencao");

                entity.Property(e => e.IdManutencao)
                    .ValueGeneratedNever()
                    .HasComment("Identificador de manutenção (PK)");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Descrição da manutenção");

                entity.Property(e => e.Periodicidade)
                    .HasColumnType("datetime")
                    .HasComment("Intervalo de tempo para cada manutenção");
            });

            modelBuilder.Entity<Motoristum>(entity =>
            {
                entity.HasKey(e => e.IdMotorista)
                    .HasName("pk_motorista")
                    .IsClustered(false);

                entity.Property(e => e.IdMotorista)
                    .ValueGeneratedNever()
                    .HasComment("Identificador do motorista (PK)");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("Cargo do motorista cadastrado");

                entity.Property(e => e.Celular)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasComment("Número de celular do motorista");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasComment("Cpf do motorista cadastrado");

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("datetime")
                    .HasComment("Data de nascimento do motorista");

                entity.Property(e => e.DataVencimentoCnh)
                    .HasColumnType("datetime")
                    .HasComment("Data de vencimento da cnh do motorista");

                entity.Property(e => e.Endereco)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("Endereço do motorista");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasComment("Nome do motorista cadastrado");

                entity.Property(e => e.Rg)
                    .HasColumnType("numeric(10, 0)")
                    .HasComment("Número do rg do motorista");

                entity.Property(e => e.Setor)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("Setor em que o motorista trabalha");

                entity.Property(e => e.TipoMotorista)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("Tipo de motorista, caro, van");
            });

            modelBuilder.Entity<Rotum>(entity =>
            {
                entity.HasKey(e => e.IdRota)
                    .HasName("pk_rota")
                    .IsClustered(false);

                entity.Property(e => e.IdRota)
                    .ValueGeneratedNever()
                    .HasComment("Identificador da rota (PK)");

                entity.Property(e => e.Destino)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Cidade de destino da rota");

                entity.Property(e => e.KmPadrao).HasComment("Distância padrão para a rota");

                entity.Property(e => e.Origem)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Cidade de origem da rota");
            });

            modelBuilder.Entity<StatusAgendamento>(entity =>
            {
                entity.HasKey(e => e.IdstatusAgendamento)
                    .HasName("pk_status_agendamento")
                    .IsClustered(false);

                entity.ToTable("StatusAgendamento");

                entity.Property(e => e.IdstatusAgendamento)
                    .ValueGeneratedNever()
                    .HasComment("Identificador de status de agendamento (PK)");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Status do agendamento");
            });

            modelBuilder.Entity<StatusVeiculo>(entity =>
            {
                entity.HasKey(e => e.IdstatusVeiculo)
                    .HasName("pk_status_veiculo")
                    .IsClustered(false);

                entity.ToTable("StatusVeiculo");

                entity.Property(e => e.IdstatusVeiculo)
                    .ValueGeneratedNever()
                    .HasComment("Identificador de status do veículo (PK)");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Status de veículo");
            });

            modelBuilder.Entity<Veiculo>(entity =>
            {
                entity.HasKey(e => e.IdVeiculo)
                    .HasName("pk_veiculo")
                    .IsClustered(false);

                entity.ToTable("Veiculo");

                entity.Property(e => e.IdVeiculo)
                    .ValueGeneratedNever()
                    .HasComment("Identificador do veículo (PK)");

                entity.Property(e => e.Ano)
                    .HasColumnType("datetime")
                    .HasComment("Ano de fabricação do veículo");

                entity.Property(e => e.Chassi)
                    .HasColumnType("numeric(18, 0)")
                    .HasComment("Número da marcação do chassi");

                entity.Property(e => e.Cor)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Descrição da cor do veículo");

                entity.Property(e => e.IdStatusVeiculo).HasComment("Identificação de status do veículo (FK STATUSVEICULO)");

                entity.Property(e => e.Km).HasComment("Quilometragem atual do veículo");

                entity.Property(e => e.Marca)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("Descrição do modelo do veículo");

                entity.Property(e => e.Modelo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("Modelo do veiculo");

                entity.Property(e => e.Observacao)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasComment("Observação do veículo");

                entity.Property(e => e.Placa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Identificação da placa do veículo");

                entity.Property(e => e.Renavam)
                    .HasColumnType("numeric(18, 0)")
                    .HasComment("Número do documento do veículo");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("Identificação do tipo do veículo");

                entity.HasOne(d => d.IdStatusVeiculoNavigation)
                    .WithMany(p => p.Veiculos)
                    .HasForeignKey(d => d.IdStatusVeiculo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_veiculo_statusveiculo");
            });

            modelBuilder.Entity<VeiculoManutencao>(entity =>
            {
                entity.HasKey(e => e.IdVeiculoManutencao)
                    .HasName("pk_veicmanu")
                    .IsClustered(false);

                entity.ToTable("VeiculoManutencao");

                entity.Property(e => e.IdVeiculoManutencao)
                    .ValueGeneratedNever()
                    .HasComment("Identificador do veiculo manutencao (PK)");

                entity.Property(e => e.DataManutencao)
                    .HasColumnType("datetime")
                    .HasComment("Data da manutenção");

                entity.Property(e => e.IdManutencao).HasComment("Identificador de manutenção (FK MANUTENCAO)");

                entity.Property(e => e.IdVeiculo).HasComment("Identificador do veículo (FK VEICULO)");

                entity.HasOne(d => d.IdManutencaoNavigation)
                    .WithMany(p => p.VeiculoManutencaos)
                    .HasForeignKey(d => d.IdManutencao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_veicmanu_manutencao");

                entity.HasOne(d => d.IdVeiculoNavigation)
                    .WithMany(p => p.VeiculoManutencaos)
                    .HasForeignKey(d => d.IdVeiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_veicmanu_veiculo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
