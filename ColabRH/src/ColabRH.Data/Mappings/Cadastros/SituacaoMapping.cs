using ColabRH.Business.Models.Cadastros;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabRH.Data.Mappings.Cadastros;

public class SituacaoMapping : IEntityTypeConfiguration<Situacao>
{
    public void Configure(EntityTypeBuilder<Situacao> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(p => p.CodigoMapeamento)
            .IsRequired()
            .HasColumnType("varchar(20)");

        builder.ToTable("Situacoes");
    }
}
