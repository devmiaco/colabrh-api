using ColabRH.Business.Models.Cadastros;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabRH.Data.Mappings.Cadastros;

public class GrupoEconomicoMapping : IEntityTypeConfiguration<GrupoEconomico>
{
    public void Configure(EntityTypeBuilder<GrupoEconomico> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.ToTable("GruposEconomicos");
    }
}
