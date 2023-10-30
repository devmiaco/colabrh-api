using ColabRH.Business.Models.Admissoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabRH.Data.Mappings.Admissoes;

public class AdmissaoFormacaoAcademicaMapping : IEntityTypeConfiguration<AdmissaoFormacaoAcademica>
{
    public void Configure(EntityTypeBuilder<AdmissaoFormacaoAcademica> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.InstituicaoEnsino)
            .HasColumnType("varchar(200)");

        builder.Property(p => p.Curso)
            .HasColumnType("varchar(200)");

        builder.Property(p => p.Certificado)
            .HasColumnType("varchar(max)");

        builder.ToTable("AdmissoesEndereco");
    }
}