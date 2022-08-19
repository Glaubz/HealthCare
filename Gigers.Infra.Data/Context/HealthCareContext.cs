using HealthCare.Domain.Entidades;
using HealthCare.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Infra.Data
{
    public class HealthCareContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Academia> Academia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-OKTCPUA\\SQLEXPRESS;Initial Catalog=HealthCare;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HealthCareContext).Assembly);

            modelBuilder.SeedData();
        }
    }
}
