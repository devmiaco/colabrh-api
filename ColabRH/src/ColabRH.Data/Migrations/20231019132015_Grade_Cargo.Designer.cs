﻿// <auto-generated />
using System;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ColabRH.Data.Migrations
{
    [DbContext(typeof(ColabRHDbContext))]
    [Migration("20231019132015_Grade_Cargo")]
    partial class Grade_Cargo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ColabRH.Business.Models.Cadastros.Cargo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CodigoMapeamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("GradeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GrupoEconomicoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.HasIndex("GrupoEconomicoId");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("ColabRH.Business.Models.Cadastros.Empresa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cnpj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GrupoEconomicoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Municipio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeFantasia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uf")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoEconomicoId");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("ColabRH.Business.Models.Cadastros.Grade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CodigoMapeamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GrupoEconomicoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoEconomicoId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("ColabRH.Business.Models.Cadastros.GrupoEconomico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GruposEconomicos");
                });

            modelBuilder.Entity("ColabRH.Business.Models.Cadastros.Cargo", b =>
                {
                    b.HasOne("ColabRH.Business.Models.Cadastros.Grade", "Grade")
                        .WithMany("Cargos")
                        .HasForeignKey("GradeId");

                    b.HasOne("ColabRH.Business.Models.Cadastros.GrupoEconomico", "GrupoEconomico")
                        .WithMany()
                        .HasForeignKey("GrupoEconomicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grade");

                    b.Navigation("GrupoEconomico");
                });

            modelBuilder.Entity("ColabRH.Business.Models.Cadastros.Empresa", b =>
                {
                    b.HasOne("ColabRH.Business.Models.Cadastros.GrupoEconomico", "GrupoEconomico")
                        .WithMany()
                        .HasForeignKey("GrupoEconomicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrupoEconomico");
                });

            modelBuilder.Entity("ColabRH.Business.Models.Cadastros.Grade", b =>
                {
                    b.HasOne("ColabRH.Business.Models.Cadastros.GrupoEconomico", "GrupoEconomico")
                        .WithMany()
                        .HasForeignKey("GrupoEconomicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrupoEconomico");
                });

            modelBuilder.Entity("ColabRH.Business.Models.Cadastros.Grade", b =>
                {
                    b.Navigation("Cargos");
                });
#pragma warning restore 612, 618
        }
    }
}
