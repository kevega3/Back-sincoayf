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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasNoKey();
            modelBuilder.Entity<Vehiculos>().Ignore(v => v.ValorBD);
        }

    }
}
