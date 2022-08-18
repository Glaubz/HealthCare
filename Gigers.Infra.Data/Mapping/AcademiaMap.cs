using HealthCare.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCare.Infra.Data.Mapping
{
    public class AcademiaMap : IEntityTypeConfiguration<Academia>
    {
        public void Configure(EntityTypeBuilder<Academia> builder)
        {
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(250)");
        }
    }
}