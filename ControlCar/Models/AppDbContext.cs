using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

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

        public virtual DbSet<Authentication> Authentication { get; set; }
        public virtual DbSet<Driver> Driver { get; set; }
        public virtual DbSet<Maintenance> Maintenance { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<Scheduling> Scheduling { get; set; }
        public virtual DbSet<StatusScheduling> StatusScheduling { get; set; }
        public virtual DbSet<StatusVehicle> StatusVehicle { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<VehicleMaintenance> VehicleMaintenance { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-S7DE1RS;Initial Catalog=ControlCar;Integrated Security=True;Pooling=False");
                // UJUSTAR CONFIGURÃÇÕES CONFORME SERVIDOR
                //optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=ControlCar;Integrated Security=True;Pooling=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authentication>(entity =>
            {
                entity.HasKey(e => e.IdAuthentication)
                    .HasName("pk_autentication")
                    .IsClustered(false);

                entity.Property(e => e.IdAuthentication).ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.User)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasKey(e => e.IdDriver)
                    .HasName("pk_Driver")
                    .IsClustered(false);

                entity.Property(e => e.IdDriver).ValueGeneratedOnAdd();

                entity.Property(e => e.Address)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Cellphone)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.ExpirationDateCnh).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Office)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Rg).HasColumnType("varchar(38, 0)");

                entity.Property(e => e.Sector)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TypeDriver)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Maintenance>(entity =>
            {
                entity.HasKey(e => e.IdMaintenance)
                    .HasName("pk_maintenance")
                    .IsClustered(false);

                entity.Property(e => e.IdMaintenance).ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Frequency).HasColumnType("datetime");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.HasKey(e => e.IdRoute)
                    .HasName("pk_Route")
                    .IsClustered(false);

                entity.Property(e => e.IdRoute).ValueGeneratedOnAdd();

                entity.Property(e => e.Destiny)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Scheduling>(entity =>
            {
                entity.HasKey(e => e.IdScheduling)
                    .HasName("pk_Scheduling")
                    .IsClustered(false);

                entity.Property(e => e.IdScheduling).ValueGeneratedOnAdd();

                entity.Property(e => e.EndDatePerformed).HasColumnType("datetime");

                entity.Property(e => e.ExpectedEndDate).HasColumnType("datetime");

                entity.Property(e => e.ExpectedStartDate).HasColumnType("datetime");

                entity.Property(e => e.StartDatePerformed).HasColumnType("datetime");

                entity.HasOne(d => d.IdDriverNavigation)
                    .WithMany(p => p.Scheduling)
                    .HasForeignKey(d => d.IdDriver)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_Scheduling_Driver");

                entity.HasOne(d => d.IdRouteNavigation)
                    .WithMany(p => p.Scheduling)
                    .HasForeignKey(d => d.IdRoute)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_Scheduling_Route");

                entity.HasOne(d => d.IdSchedulingNavigation)
                    .WithOne(p => p.Scheduling)
                    .HasForeignKey<Scheduling>(d => d.IdScheduling)
                    .HasConstraintName("fk_Scheduling_authentication");

                entity.HasOne(d => d.IdStatusSchedulingNavigation)
                    .WithMany(p => p.Scheduling)
                    .HasForeignKey(d => d.IdStatusScheduling)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_Scheduling_status_Scheduling");

                entity.HasOne(d => d.IdVehicleNavigation)
                    .WithMany(p => p.Scheduling)
                    .HasForeignKey(d => d.IdVehicle)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_Scheduling_Vehicle");
            });

            modelBuilder.Entity<StatusScheduling>(entity =>
            {
                entity.HasKey(e => e.IdstatusScheduling)
                    .HasName("pk_status_Scheduling")
                    .IsClustered(false);

                entity.Property(e => e.IdstatusScheduling).ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatusVehicle>(entity =>
            {
                entity.HasKey(e => e.IdstatusVehicle)
                    .HasName("pk_status_vehicle")
                    .IsClustered(false);

                entity.Property(e => e.IdstatusVehicle).ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.IdVehicle)
                    .HasName("pk_Vehicle")
                    .IsClustered(false);

                entity.Property(e => e.IdVehicle).ValueGeneratedOnAdd();

                entity.Property(e => e.Board)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Brand)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Chassi).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Color)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Observation)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Renavam).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Year).HasColumnType("datetime");

                entity.HasOne(d => d.IdStatusVehicleNavigation)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.IdStatusVehicle)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_Vehicle_statusVehicle");
            });

            modelBuilder.Entity<VehicleMaintenance>(entity =>
            {
                entity.HasKey(e => e.IdVehicleMaintenance)
                    .HasName("pk_veicmanu")
                    .IsClustered(false);

                entity.Property(e => e.IdVehicleMaintenance).ValueGeneratedOnAdd();

                entity.Property(e => e.DateMaintenance).HasColumnType("datetime");

                entity.HasOne(d => d.IdMaintenanceNavigation)
                    .WithMany(p => p.VehicleMaintenance)
                    .HasForeignKey(d => d.IdMaintenance)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_veicmanu_maintenance");

                entity.HasOne(d => d.IdVehicleNavigation)
                    .WithMany(p => p.VehicleMaintenance)
                    .HasForeignKey(d => d.IdVehicle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_veicmanu_Vehicle");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
