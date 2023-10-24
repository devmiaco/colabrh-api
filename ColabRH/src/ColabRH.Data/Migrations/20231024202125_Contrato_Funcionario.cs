using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColabRH.Data.Migrations
{
    /// <inheritdoc />
    public partial class Contrato_Funcionario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContratosElegibilidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContratoBeneficioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoContribuicaoTitular = table.Column<int>(type: "int", nullable: false),
                    ValorTitular = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoContribuicaoDependente = table.Column<int>(type: "int", nullable: false),
                    ValorDependente = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratosElegibilidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContratosElegibilidade_ContratosBeneficio_ContratoBeneficioId",
                        column: x => x.ContratoBeneficioId,
                        principalTable: "ContratosBeneficio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ContratosGrauParentesco",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContratoBeneficioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrauParentescoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratosGrauParentesco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContratosGrauParentesco_ContratosBeneficio_ContratoBeneficioId",
                        column: x => x.ContratoBeneficioId,
                        principalTable: "ContratosBeneficio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ContratosGrauParentesco_GrausParentesco_GrauParentescoId",
                        column: x => x.GrauParentescoId,
                        principalTable: "GrausParentesco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ContratosPlano",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContratoBeneficioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratosPlano", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContratosPlano_ContratosBeneficio_ContratoBeneficioId",
                        column: x => x.ContratoBeneficioId,
                        principalTable: "ContratosBeneficio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ContratosPlano_Planos_PlanoId",
                        column: x => x.PlanoId,
                        principalTable: "Planos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ContratosSubestipulante",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContratoBeneficioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoEmpresaOperadora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratosSubestipulante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContratosSubestipulante_ContratosBeneficio_ContratoBeneficioId",
                        column: x => x.ContratoBeneficioId,
                        principalTable: "ContratosBeneficio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoEconomicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GradeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CargoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SindicatoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VinculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SituacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Matricula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataAdmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoSexo = table.Column<int>(type: "int", nullable: false),
                    TipoEstadoCivil = table.Column<int>(type: "int", nullable: false),
                    DataCasamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NomeMae = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomePai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Peso = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Altura = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefoneFixo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefoneCelular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailPessoal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailCorporativo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Municipio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uf = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Funcionarios_GruposEconomicos_GrupoEconomicoId",
                        column: x => x.GrupoEconomicoId,
                        principalTable: "GruposEconomicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Sindicatos_SindicatoId",
                        column: x => x.SindicatoId,
                        principalTable: "Sindicatos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Funcionarios_Situacoes_SituacaoId",
                        column: x => x.SituacaoId,
                        principalTable: "Situacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Vinculos_VinculoId",
                        column: x => x.VinculoId,
                        principalTable: "Vinculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ContratosElegibilidadeCargo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContratoBeneficioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContratoElegibilidadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CargoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratosElegibilidadeCargo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContratosElegibilidadeCargo_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ContratosElegibilidadeCargo_ContratosBeneficio_ContratoBeneficioId",
                        column: x => x.ContratoBeneficioId,
                        principalTable: "ContratosBeneficio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ContratosElegibilidadeCargo_ContratosElegibilidade_ContratoElegibilidadeId",
                        column: x => x.ContratoElegibilidadeId,
                        principalTable: "ContratosElegibilidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ContratosElegibilidadeGrade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContratoBeneficioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContratoElegibilidadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GradeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratosElegibilidadeGrade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContratosElegibilidadeGrade_ContratosBeneficio_ContratoBeneficioId",
                        column: x => x.ContratoBeneficioId,
                        principalTable: "ContratosBeneficio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ContratosElegibilidadeGrade_ContratosElegibilidade_ContratoElegibilidadeId",
                        column: x => x.ContratoElegibilidadeId,
                        principalTable: "ContratosElegibilidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ContratosElegibilidadeGrade_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Dependentes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrauParentescoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoSexo = table.Column<int>(type: "int", nullable: false),
                    TipoEstadoCivil = table.Column<int>(type: "int", nullable: false),
                    DataCasamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NomeMae = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomePai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Peso = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Altura = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroNascidoVivo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dependentes_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Dependentes_GrausParentesco_GrauParentescoId",
                        column: x => x.GrauParentescoId,
                        principalTable: "GrausParentesco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FuncionarioBeneficios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperadoraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContratoBeneficioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContratoPlanoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroCartao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Desconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InicioVigencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TerminoVigencia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TipoStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioBeneficios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuncionarioBeneficios_ContratosBeneficio_ContratoBeneficioId",
                        column: x => x.ContratoBeneficioId,
                        principalTable: "ContratosBeneficio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FuncionarioBeneficios_ContratosPlano_ContratoPlanoId",
                        column: x => x.ContratoPlanoId,
                        principalTable: "ContratosPlano",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FuncionarioBeneficios_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FuncionarioBeneficios_Operadoras_OperadoraId",
                        column: x => x.OperadoraId,
                        principalTable: "Operadoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FuncionarioBeneficios_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DependenteBeneficios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionarioBeneficioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DependenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroCartao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Desconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InicioVigencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TerminoVigencia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TipoStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DependenteBeneficios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DependenteBeneficios_Dependentes_DependenteId",
                        column: x => x.DependenteId,
                        principalTable: "Dependentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DependenteBeneficios_FuncionarioBeneficios_FuncionarioBeneficioId",
                        column: x => x.FuncionarioBeneficioId,
                        principalTable: "FuncionarioBeneficios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContratosElegibilidade_ContratoBeneficioId",
                table: "ContratosElegibilidade",
                column: "ContratoBeneficioId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosElegibilidadeCargo_CargoId",
                table: "ContratosElegibilidadeCargo",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosElegibilidadeCargo_ContratoBeneficioId",
                table: "ContratosElegibilidadeCargo",
                column: "ContratoBeneficioId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosElegibilidadeCargo_ContratoElegibilidadeId",
                table: "ContratosElegibilidadeCargo",
                column: "ContratoElegibilidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosElegibilidadeGrade_ContratoBeneficioId",
                table: "ContratosElegibilidadeGrade",
                column: "ContratoBeneficioId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosElegibilidadeGrade_ContratoElegibilidadeId",
                table: "ContratosElegibilidadeGrade",
                column: "ContratoElegibilidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosElegibilidadeGrade_GradeId",
                table: "ContratosElegibilidadeGrade",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosGrauParentesco_ContratoBeneficioId",
                table: "ContratosGrauParentesco",
                column: "ContratoBeneficioId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosGrauParentesco_GrauParentescoId",
                table: "ContratosGrauParentesco",
                column: "GrauParentescoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosPlano_ContratoBeneficioId",
                table: "ContratosPlano",
                column: "ContratoBeneficioId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosPlano_PlanoId",
                table: "ContratosPlano",
                column: "PlanoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosSubestipulante_ContratoBeneficioId",
                table: "ContratosSubestipulante",
                column: "ContratoBeneficioId");

            migrationBuilder.CreateIndex(
                name: "IX_DependenteBeneficios_DependenteId",
                table: "DependenteBeneficios",
                column: "DependenteId");

            migrationBuilder.CreateIndex(
                name: "IX_DependenteBeneficios_FuncionarioBeneficioId",
                table: "DependenteBeneficios",
                column: "FuncionarioBeneficioId");

            migrationBuilder.CreateIndex(
                name: "IX_Dependentes_FuncionarioId",
                table: "Dependentes",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Dependentes_GrauParentescoId",
                table: "Dependentes",
                column: "GrauParentescoId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioBeneficios_ContratoBeneficioId",
                table: "FuncionarioBeneficios",
                column: "ContratoBeneficioId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioBeneficios_ContratoPlanoId",
                table: "FuncionarioBeneficios",
                column: "ContratoPlanoId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioBeneficios_FuncionarioId",
                table: "FuncionarioBeneficios",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioBeneficios_OperadoraId",
                table: "FuncionarioBeneficios",
                column: "OperadoraId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioBeneficios_ProdutoId",
                table: "FuncionarioBeneficios",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_CargoId",
                table: "Funcionarios",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_DepartamentoId",
                table: "Funcionarios",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_EmpresaId",
                table: "Funcionarios",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_GradeId",
                table: "Funcionarios",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_GrupoEconomicoId",
                table: "Funcionarios",
                column: "GrupoEconomicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_SindicatoId",
                table: "Funcionarios",
                column: "SindicatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_SituacaoId",
                table: "Funcionarios",
                column: "SituacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_VinculoId",
                table: "Funcionarios",
                column: "VinculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContratosElegibilidadeCargo");

            migrationBuilder.DropTable(
                name: "ContratosElegibilidadeGrade");

            migrationBuilder.DropTable(
                name: "ContratosGrauParentesco");

            migrationBuilder.DropTable(
                name: "ContratosSubestipulante");

            migrationBuilder.DropTable(
                name: "DependenteBeneficios");

            migrationBuilder.DropTable(
                name: "ContratosElegibilidade");

            migrationBuilder.DropTable(
                name: "Dependentes");

            migrationBuilder.DropTable(
                name: "FuncionarioBeneficios");

            migrationBuilder.DropTable(
                name: "ContratosPlano");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
