using ColabRH.Business.Models.Admissoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabRH.Data.Mappings.Admissoes;

public class AdmissaoDependenteMapping : IEntityTypeConfiguration<AdmissaoDependente>
{
    public void Configure(EntityTypeBuilder<AdmissaoDependente> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(p => p.NomeMae)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(p => p.NomePai)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(p => p.Peso)
            .HasPrecision(15, 2);

        builder.Property(p => p.Altura)
            .HasPrecision(15, 2);

        builder.Property(p => p.Cpf)
            .IsRequired()
            .HasColumnType("varchar(20)");

        builder.Property(p => p.Rg)
            .HasColumnType("varchar(20)");

        builder.Property(p => p.Cns)
            .HasColumnType("varchar(20)");

        builder.Property(p => p.NumeroNascidoVivo)
            .HasColumnType("varchar(20)");

        builder.ToTable("AdmissoesDependentes");
    }
}