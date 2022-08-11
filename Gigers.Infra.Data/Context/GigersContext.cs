using Gigers.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Gigers.Infra.Data
{
    public class GigersContext : DbContext
    {
        public DbSet<Giger> Giger { get; set; }
        public DbSet<Gig> Gig { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-OKTCPUA\\SQLEXPRESS;Initial Catalog=Gigers;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GigersContext).Assembly);
        }
    }
}
