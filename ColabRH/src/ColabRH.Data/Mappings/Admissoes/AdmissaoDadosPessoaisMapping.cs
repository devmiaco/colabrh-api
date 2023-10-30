using ColabRH.Business.Models.Admissoes;
using ColabRH.Business.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColabRH.Data.Mappings.Admissoes;

public class AdmissaoDadosPessoaisMapping : IEntityTypeConfiguration<AdmissaoDadosPessoais>
{
    public void Configure(EntityTypeBuilder<AdmissaoDadosPessoais> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.NomeSocial)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(p => p.NomeMae)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(p => p.NomePai)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(p => p.ObservacaoDeficiencia)
            .IsRequired()
            .HasColumnType("varchar(250)");

        builder.ToTable("AdmissoesDadosPessoais");
    }
}