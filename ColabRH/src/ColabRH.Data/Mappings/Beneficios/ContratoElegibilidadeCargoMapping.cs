using ColabRH.Business.Models.Beneficios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabRH.Data.Mappings.Beneficios;

public class ContratoElegibilidadeCargoMapping : IEntityTypeConfiguration<ContratoElegibilidadeCargo>
{
    public void Configure(EntityTypeBuilder<ContratoElegibilidadeCargo> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.ToTable("ContratosElegibilidadeCargo");
    }
}
