using HealthCare.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCare.Infra.Data.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(250)");

            builder.Property(p => p.CPF).HasColumnType("CHAR(11)")
                                        .HasMaxLength(11)
                                        .IsFixedLength()
                                        .IsRequired();
        }
    }
}
