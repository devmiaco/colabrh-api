using ColabRH.Business.Models.Beneficios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabRH.Data.Mappings.Beneficios;

public class ContratoGrauParentescoMapping : IEntityTypeConfiguration<ContratoGrauParentesco>
{
    public void Configure(EntityTypeBuilder<ContratoGrauParentesco> builder)
    {
        builder.HasKey(p => p.Id);

        builder.ToTable("ContratosGrauParentesco");
    }
}
