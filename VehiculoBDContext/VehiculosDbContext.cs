using Back_sincoayf.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Back_sincoayf.VehiculoBDContext
{
    public class VehiculosDbContext : DbContext
    {
        public VehiculosDbContext(DbContextOptions<VehiculosDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Vehiculos> Vehiculos { get; set; }
        public DbSet<ListaPrecios> ListaPrecios { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Comprador> Compradores { get; set; }
        public DbSet<VentaComprador> VentaComprador { get; set; }
        public DbSet<Reporte> Reportes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasNoKey();
            modelBuilder.Entity<Vehiculos>().Ignore(v => v.ValorBD);
            modelBuilder.Entity<VentaComprador>().HasNoKey();
            modelBuilder.Entity<Reporte>().HasNoKey();
        }

    }
}
