using ColabRH.Business.Models.Beneficios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabRH.Data.Mappings.Beneficios;

public class ContratoElegibilidadeGradeMapping : IEntityTypeConfiguration<ContratoElegibilidadeGrade>
{
    public void Configure(EntityTypeBuilder<ContratoElegibilidadeGrade> builder)
    {
        builder.HasKey(p => p.Id);

        builder.ToTable("ContratosElegibilidadeGrade");
    }
}
