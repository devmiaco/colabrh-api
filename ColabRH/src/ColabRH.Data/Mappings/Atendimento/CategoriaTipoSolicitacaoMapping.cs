using ColabRH.Business.Models.Atendimento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabRH.Data.Mappings.Atendimento;

public class CategoriaTipoSolicitacaoMapping : IEntityTypeConfiguration<CategoriaTipoSolicitacao>
{
    public void Configure(EntityTypeBuilder<CategoriaTipoSolicitacao> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(250)");

        builder.ToTable("CategoriasTipoSolicitacao");
    }
}
