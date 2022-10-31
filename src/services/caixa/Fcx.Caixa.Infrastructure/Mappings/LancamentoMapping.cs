using Fcx.Caixa.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fcx.Caixa.Infrastructure.Mappings
{
    public class LancamentoMapping : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.HasKey(c => c.Identificador);

            builder.Property(c => c.CodigoLancamento)
                .IsRequired()
                .HasColumnType("smallint");

            builder.Property(c => c.Finalidade)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.TipoDC)
                .IsRequired()
                .HasColumnType("char");

            builder.Property(c => c.DataHoraCriacao)
                .HasColumnType("datetime");

            // 1 : N => Lancamento : Movimento
            builder.HasMany(c => c.Movimento)
                .WithOne(c => c.Lancamento)
                .HasForeignKey(c => c.LancamentoId);

            builder.ToTable("Lancamento");
        }
    }
}
