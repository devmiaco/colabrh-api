using ColabRH.Business.Models.Funcionarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabRH.Data.Mappings.Funcionarios;

public class FuncionarioBeneficioMapping : IEntityTypeConfiguration<FuncionarioBeneficio>
{
    public void Configure(EntityTypeBuilder<FuncionarioBeneficio> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.NumeroCartao)
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder.Property(p => p.Valor)
            .IsRequired()
            .HasColumnType("decimal(15,2)")
            .HasPrecision(15, 2);

        builder.Property(p => p.Desconto)
            .IsRequired()
            .HasColumnType("decimal(15,2)")
            .HasPrecision(15, 2);

        builder.ToTable("FuncionarioBeneficios");
    }
}
