using ColabRH.Business.Models.Cadastros;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColabRH.Data.Mappings;

internal class EmpresaMapping : IEntityTypeConfiguration<Empresa>
{
    public void Configure(EntityTypeBuilder<Empresa> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Cnpj)
            .IsRequired()
            .HasColumnType("varchar(20)");

        builder.Property(p => p.RazaoSocial)
            .IsRequired()
            .HasColumnType("varchar(250)");

        builder.Property(p => p.NomeFantasia)
            .IsRequired()
            .HasColumnType("varchar(250)");

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

        builder.ToTable("Empresas");
    }
}
