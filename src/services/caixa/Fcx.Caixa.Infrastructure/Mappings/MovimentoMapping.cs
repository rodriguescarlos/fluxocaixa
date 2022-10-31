using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Fcx.Caixa.Domain;

namespace Fcx.Caixa.Infrastructure.Mappings
{
    public class MovimentoMapping : IEntityTypeConfiguration<Movimento>
    {
        public void Configure(EntityTypeBuilder<Movimento> builder)
        {
            builder.HasKey(c => c.Identificador);

            builder.Property(c => c.Valor)
                .IsRequired()
                .HasColumnType("decimal")
                .HasPrecision(18,2);

            builder.Property(c => c.DataMovimento)
                .IsRequired()
                .HasColumnType("datetime");

            builder.ToTable("Movimento");
        }
    }
}
