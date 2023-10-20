using ColabRH.Business.Models.Cadastros;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabRH.Data.Mappings.Cadastros;

public class PlanoMapping : IEntityTypeConfiguration<Plano>
{
    public void Configure(EntityTypeBuilder<Plano> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(p => p.Codigo)
            .IsRequired()
            .HasColumnType("varchar(20)");

        builder.Property(p => p.Descricao)
            .IsRequired()
            .HasColumnType("varchar(250)");

        builder.ToTable("Planos");
    }
}
