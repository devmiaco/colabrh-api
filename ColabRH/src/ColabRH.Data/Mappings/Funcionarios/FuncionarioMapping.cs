using ColabRH.Business.Models.Funcionarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabRH.Data.Mappings.Funcionarios;

public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
{
    public void Configure(EntityTypeBuilder<Funcionario> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Matricula)
            .IsRequired()
            .HasColumnType("varchar(200)");

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

        builder.Property(p => p.TelefoneFixo)
            .HasColumnType("varchar(20)");

        builder.Property(p => p.TelefoneCelular)
            .HasColumnType("varchar(20)");

        builder.Property(p => p.EmailPessoal)
            .HasColumnType("varchar(200)");

        builder.Property(p => p.EmailCorporativo)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(p => p.Cep)
            .HasColumnType("varchar(10)");

        builder.Property(p => p.Logradouro)
            .HasColumnType("varchar(250)");

        builder.Property(p => p.Numero)
            .HasColumnType("varchar(10)");

        builder.Property(p => p.Complemento)
            .HasColumnType("varchar(100)");

        builder.Property(p => p.Bairro)
            .HasColumnType("varchar(100)");

        builder.Property(p => p.Municipio)
            .HasColumnType("varchar(150)");

        builder.Property(p => p.Uf)
            .HasColumnType("varchar(2)");

        builder.ToTable("Funcionarios");
    }
}