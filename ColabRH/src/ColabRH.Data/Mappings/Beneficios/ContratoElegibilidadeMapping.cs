using ColabRH.Business.Models.Beneficios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabRH.Data.Mappings.Beneficios;

public class ContratoElegibilidadeMapping : IEntityTypeConfiguration<ContratoElegibilidade>
{
    public void Configure(EntityTypeBuilder<ContratoElegibilidade> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(p => p.ValorTitular)
            .IsRequired()
            .HasColumnType("decimal(15,2)")
            .HasPrecision(15, 2);

        builder.Property(p => p.ValorDependente)
            .IsRequired()
            .HasColumnType("decimal(15,2)")
            .HasPrecision(15, 2);

        builder.ToTable("ContratosElegibilidade");
    }
}
