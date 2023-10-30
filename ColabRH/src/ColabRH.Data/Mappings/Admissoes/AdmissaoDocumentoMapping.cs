using ColabRH.Business.Models.Admissoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabRH.Data.Mappings.Admissoes;

public class AdmissaoDocumentoMapping : IEntityTypeConfiguration<AdmissaoDocumento>
{
    public void Configure(EntityTypeBuilder<AdmissaoDocumento> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.RgNumero)
            .HasColumnType("varchar(20)");

        builder.Property(p => p.RgOrgaoEmissor)
            .HasColumnType("varchar(20)");

        builder.Property(p => p.RgFrenteComprovante)
            .HasColumnType("varchar(max)");

        builder.Property(p => p.RgVersoComprovante)
            .HasColumnType("varchar(max)");

        builder.Property(p => p.CnhNumero)
            .HasColumnType("varchar(20)");

        builder.Property(p => p.CnhCategoria)
            .HasColumnType("varchar(5)");

        builder.Property(p => p.CnhComprovante)
            .HasColumnType("varchar(max)");

        builder.Property(p => p.CpfNumero)
            .HasColumnType("varchar(20)");

        builder.Property(p => p.CpfComprovante)
            .HasColumnType("varchar(max)");

        builder.Property(p => p.ReservistaNumero)
            .HasColumnType("varchar(20)");

        builder.Property(p => p.ReservistaRA)
            .HasColumnType("varchar(20)");

        builder.Property(p => p.ReservistaCategoria)
            .HasColumnType("varchar(20)");

        builder.Property(p => p.ReservistaComprovante)
            .HasColumnType("varchar(max)");

        builder.Property(p => p.TituloEleitorNumero)
            .HasColumnType("varchar(20)");

        builder.Property(p => p.TituloEleitorZonaEleitoral)
            .HasColumnType("varchar(max)");

        builder.Property(p => p.TituloEleitorSecaoEleitoral)
            .HasColumnType("varchar(max)");

        builder.Property(p => p.TituloEleitorComprovante)
            .HasColumnType("varchar(max)");

        builder.Property(p => p.CarteiraTrabalhoNumero)
            .HasColumnType("varchar(max)");

        builder.Property(p => p.CarteiraTrabalhoSerie)
            .HasColumnType("varchar(max)");

        builder.Property(p => p.CarteiraTrabalhoPIS)
            .HasColumnType("varchar(max)");

        builder.Property(p => p.CarteiraTrabalhoPrimeiraFolhaComprovante)
            .HasColumnType("varchar(max)");

        builder.Property(p => p.CarteiraTrabalhoSegundaFolhaComprovante)
            .HasColumnType("varchar(max)");

        builder.ToTable("AdmissoesDocumentos");
    }
}