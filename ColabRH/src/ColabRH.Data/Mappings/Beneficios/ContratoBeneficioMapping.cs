using ColabRH.Business.Models.Beneficios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabRH.Data.Mappings.Beneficios;

public class ContratoBeneficioMapping : IEntityTypeConfiguration<ContratoBeneficio>
{
    public void Configure(EntityTypeBuilder<ContratoBeneficio> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.CodigoEmpresaOperadora)
            .IsRequired()
            .HasColumnType("varchar(20)");

        builder.Property(p => p.CodigoContrato)
            .IsRequired()
            .HasColumnType("varchar(20)");
        
        builder.ToTable("ContratosBeneficio");
    }
}
