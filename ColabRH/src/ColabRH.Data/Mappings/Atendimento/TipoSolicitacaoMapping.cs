using ColabRH.Business.Models.Atendimento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabRH.Data.Mappings.Atendimento;

public class TipoSolicitacaoMapping : IEntityTypeConfiguration<TipoSolicitacao>
{
    public void Configure(EntityTypeBuilder<TipoSolicitacao> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(250)");

        builder.ToTable("Solicitacoes");
    }
}
