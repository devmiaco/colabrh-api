using ColabRH.Business.Models.Cadastros;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabRH.Data.Mappings.Cadastros;

public class OperadoraMapping : IEntityTypeConfiguration<Operadora>
{
    public void Configure(EntityTypeBuilder<Operadora> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Cnpj)
            .IsRequired()
            .HasColumnType("varchar(20)");

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(p => p.Telefone)
            .IsRequired()
            .HasColumnType("varchar(20)");

        builder.ToTable("Operadoras");
    }
}
