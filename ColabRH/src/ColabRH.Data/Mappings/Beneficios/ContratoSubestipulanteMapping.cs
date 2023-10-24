using ColabRH.Business.Models.Beneficios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabRH.Data.Mappings.Beneficios;

public class ContratoSubestipulanteMapping : IEntityTypeConfiguration<ContratoSubestipulante>
{
    public void Configure(EntityTypeBuilder<ContratoSubestipulante> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.CodigoEmpresaOperadora)
        .IsRequired()
        .HasColumnType("varchar(20)");

        builder.ToTable("ContratosSubestipulante");
    }
}
