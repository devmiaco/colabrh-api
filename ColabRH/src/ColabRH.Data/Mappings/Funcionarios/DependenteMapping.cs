using ColabRH.Business.Models.Funcionarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabRH.Data.Mappings.Funcionarios;

public class DependenteMapping : IEntityTypeConfiguration<Dependente>
{
    public void Configure(EntityTypeBuilder<Dependente> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(p => p.NomeMae)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(p => p.NomePai)
            .HasColumnType("varchar(200)");

        builder.Property(p => p.Peso)
            .HasColumnType("decimal(15,2)")
            .HasPrecision(15, 2);

        builder.Property(p => p.Altura)
            .HasColumnType("decimal(15,2)")
            .HasPrecision(15, 2);

        builder.Property(p => p.Cpf)
            .IsRequired()
            .HasColumnType("varchar(20)");

        builder.Property(p => p.Rg)
            .HasColumnType("varchar(20)");

        builder.Property(p => p.Cns)
            .HasColumnType("varchar(20)");

        builder.Property(p => p.NumeroNascidoVivo)
            .HasColumnType("varchar(20)");

        builder.ToTable("Dependentes");
    }
}