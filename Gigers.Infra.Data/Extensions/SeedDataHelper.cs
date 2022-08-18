using HealthCare.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HealthCare.Infra.Data.Extensions
{
    public static class SeedDataHelper
    {
        public static ModelBuilder SeedData(this ModelBuilder modelBuilder)
        {
            List<Usuario> _usuarios = new List<Usuario>(){
                new Usuario
                {
                    Id = new System.Guid("C1F75045-3C5D-40BC-9443-F6B0CF65016C"),
                    Nome = "Administrador",
                    CPF = "45894916054",
                    Endereco = null
                }
            };

            modelBuilder.Entity<Usuario>()
                        .HasData(_usuarios);

            return modelBuilder;
        }
    }
}
