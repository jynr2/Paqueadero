using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Parqueadero.Repository.Repository;

#nullable disable

namespace Parqueadero.Repository.Context
{
    public partial class ParqueaderoDBContext : DbContext
    {
        public ParqueaderoDBContext()
        {
        }

        public ParqueaderoDBContext(DbContextOptions<ParqueaderoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Entrada> Entrada { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Salida> Salida { get; set; }
        public virtual DbSet<TiposVehiculo> TiposVehiculos { get; set; }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Entrada>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaIngreso");

                entity.Property(e => e.Puesto)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("puesto");

                entity.Property(e => e.VehiculoId).HasColumnName("vehiculoId");

                entity.HasOne(d => d.Vehiculo)
                    .WithMany(p => p.Entrada)
                    .HasForeignKey(d => d.VehiculoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entrada_Vehiculo");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("Persona");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.NoCedula).HasColumnName("noCedula");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Salida>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AplicaDescuento).HasColumnName("aplicaDescuento");

                entity.Property(e => e.EntradaId).HasColumnName("entradaId");

                entity.Property(e => e.FechaSalida)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaSalida");

                entity.Property(e => e.NoFacturaDescuento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("noFacturaDescuento");

                entity.Property(e => e.Pago)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("pago");

                entity.HasOne(d => d.Entrada)
                    .WithMany(p => p.Salida)
                    .HasForeignKey(d => d.EntradaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Salida_Entrada");
            });

            modelBuilder.Entity<TiposVehiculo>(entity =>
            {
                entity.ToTable("TiposVehiculo");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.TipoNombre)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("tipoNombre");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.ToTable("Vehiculo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("color");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.Property(e => e.PersonaId).HasColumnName("personaId");

                entity.Property(e => e.Placa)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("placa");

                entity.Property(e => e.TipoVehiculoId).HasColumnName("tipoVehiculoId");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.PersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehiculo_Persona");

                entity.HasOne(d => d.TipoVehiculo)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.TipoVehiculoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehiculo_TiposVehiculo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
