using ColabRH.Business.Models.Atendimento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabRH.Data.Mappings.Atendimento;

public class SolicitacaoMapping : IEntityTypeConfiguration<Solicitacao>
{
    public void Configure(EntityTypeBuilder<Solicitacao> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Assunto)
            .IsRequired()
            .HasColumnType("varchar(250)");

        builder.Property(p => p.Descricao)
            .IsRequired()
            .HasColumnType("varchar(500)");

        builder.Property(p => p.Anexo)
            .IsRequired()
            .HasColumnType("varchar(max)");        

        builder.ToTable("Solicitacoes");
    }
}
