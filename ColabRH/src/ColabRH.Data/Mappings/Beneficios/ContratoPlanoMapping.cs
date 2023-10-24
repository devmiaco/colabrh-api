using ColabRH.Business.Models.Beneficios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabRH.Data.Mappings.Beneficios
{
    public class ContratoPlanoMapping : IEntityTypeConfiguration<ContratoPlano>
    {
        public void Configure(EntityTypeBuilder<ContratoPlano> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Valor)
            .IsRequired()
            .HasColumnType("decimal(15,2)");

            builder.ToTable("ContratosPlano");
        }
    }
}
