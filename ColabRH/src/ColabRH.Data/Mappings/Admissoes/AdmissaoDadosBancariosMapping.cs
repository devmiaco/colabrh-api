using ColabRH.Business.Models.Admissoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabRH.Data.Mappings.Admissoes;

public class AdmissaoDadosBancariosMapping : IEntityTypeConfiguration<AdmissaoDadosBancarios>
{
    public void Configure(EntityTypeBuilder<AdmissaoDadosBancarios> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Agencia)
            .IsRequired()
            .HasColumnType("varchar(20)");

        builder.Property(p => p.Conta)
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder.Property(p => p.DigitoConta)
            .IsRequired()
            .HasColumnType("varchar(5)");

        builder.Property(p => p.ChavePix)
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder.ToTable("AdmissoesDadosBancarios");
    }
}