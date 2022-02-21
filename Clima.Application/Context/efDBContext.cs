using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Clima.Application.Models;

namespace Clima.Application.Context
{
    public partial class efDBContext : DbContext
    {
        public efDBContext()
            : base("name=efDBContext")
        {
        }

        public virtual DbSet<CidadeModel> Cidade { get; set; }
        public virtual DbSet<EstadoModel> Estado { get; set; }
        public virtual DbSet<PrevisaoClimaModel> PrevisaoClima { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CidadeModel>()
                .HasMany(e => e.PrevisaoClima)
                .WithRequired(e => e.Cidade)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstadoModel>()
                .HasMany(e => e.Cidade)
                .WithRequired(e => e.Estado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PrevisaoClimaModel>()
                .Property(e => e.TemperaturaMinima)
                .HasPrecision(3, 1);

            modelBuilder.Entity<PrevisaoClimaModel>()
                .Property(e => e.TemperaturaMaxima)
                .HasPrecision(3, 1);
        }
    }
}