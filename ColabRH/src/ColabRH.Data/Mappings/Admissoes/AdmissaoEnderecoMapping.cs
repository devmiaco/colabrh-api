using ColabRH.Business.Models.Admissoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabRH.Data.Mappings.Admissoes;

public class AdmissaoEnderecoMapping : IEntityTypeConfiguration<AdmissaoEndereco>
{
    public void Configure(EntityTypeBuilder<AdmissaoEndereco> builder)
    {
        builder.HasKey(p => p.Id);

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

        builder.Property(p => p.ComprovanteResidencia)
            .HasColumnType("varchar(max)");

        builder.Property(p => p.TelefoneResidencial)
            .HasColumnType("varchar(20)");

        builder.Property(p => p.TelefoneCelular)
            .HasColumnType("varchar(20)");

        builder.Property(p => p.EmailPessoal)
            .HasColumnType("varchar(100)");

        builder.ToTable("AdmissoesEndereco");
    }
}