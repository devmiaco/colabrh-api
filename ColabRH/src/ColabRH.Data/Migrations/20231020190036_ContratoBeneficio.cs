using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColabRH.Data.Migrations
{
    /// <inheritdoc />
    public partial class ContratoBeneficio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContratosBeneficio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoEconomicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperadoraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoEmpresaOperadora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoContrato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoCliente = table.Column<int>(type: "int", nullable: false),
                    TipoCusteio = table.Column<int>(type: "int", nullable: false),
                    DataInicioVigencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataTerminoVigencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TempoVigencia = table.Column<int>(type: "int", nullable: false),
                    DataAniversario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInicioOperacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoNegocio = table.Column<int>(type: "int", nullable: false),
                    DiaCorte = table.Column<int>(type: "int", nullable: false),
                    DiaLiberacaoFatura = table.Column<int>(type: "int", nullable: false),
                    DiaVencimentoFatura = table.Column<int>(type: "int", nullable: false),
                    DependenteMaiorIdade = table.Column<int>(type: "int", nullable: false),
                    DependenteUniversitarioIdade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratosBeneficio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContratosBeneficio_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ContratosBeneficio_GruposEconomicos_GrupoEconomicoId",
                        column: x => x.GrupoEconomicoId,
                        principalTable: "GruposEconomicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ContratosBeneficio_Operadoras_OperadoraId",
                        column: x => x.OperadoraId,
                        principalTable: "Operadoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ContratosBeneficio_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContratosBeneficio_EmpresaId",
                table: "ContratosBeneficio",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosBeneficio_GrupoEconomicoId",
                table: "ContratosBeneficio",
                column: "GrupoEconomicoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosBeneficio_OperadoraId",
                table: "ContratosBeneficio",
                column: "OperadoraId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosBeneficio_ProdutoId",
                table: "ContratosBeneficio",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContratosBeneficio");
        }
    }
}
