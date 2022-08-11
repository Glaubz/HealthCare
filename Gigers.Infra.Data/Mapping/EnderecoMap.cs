using Gigers.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gigers.Infra.Data.Mapping
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.Property(p => p.CEP)
                   .HasMaxLength(8)
                   .IsFixedLength()
                   .IsRequired();
        }
    }
}
