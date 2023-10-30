using ColabRH.Business.Models.Admissoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabRH.Data.Mappings.Admissoes;

public class AdmissaoMapping : IEntityTypeConfiguration<Admissao>
{
    public void Configure(EntityTypeBuilder<Admissao> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(250)");

        builder.Property(p => p.EmailPessoal)
            .IsRequired()
            .HasColumnType("varchar(250)");

        builder.Property(p => p.Salario)
            .HasPrecision(15, 2);

        builder.Property(p => p.FotoPerfil)
            .HasColumnType("varchar(max)");

        builder.ToTable("Admissoes");
    }
}