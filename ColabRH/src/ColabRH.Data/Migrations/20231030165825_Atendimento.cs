using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColabRH.Data.Migrations
{
    /// <inheritdoc />
    public partial class Atendimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriasTipoSolicitacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoEconomicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasTipoSolicitacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoriasTipoSolicitacao_GruposEconomicos_GrupoEconomicoId",
                        column: x => x.GrupoEconomicoId,
                        principalTable: "GruposEconomicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TiposSolicitacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoEconomicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriaTipoSolicitacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposSolicitacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiposSolicitacao_CategoriasTipoSolicitacao_CategoriaTipoSolicitacaoId",
                        column: x => x.CategoriaTipoSolicitacaoId,
                        principalTable: "CategoriasTipoSolicitacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TiposSolicitacao_GruposEconomicos_GrupoEconomicoId",
                        column: x => x.GrupoEconomicoId,
                        principalTable: "GruposEconomicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Solicitacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoEconomicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoSolicitacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataAbertura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFechamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TipoStatus = table.Column<int>(type: "int", nullable: false),
                    Assunto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Anexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioResponsavel = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitacoes_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Solicitacoes_GruposEconomicos_GrupoEconomicoId",
                        column: x => x.GrupoEconomicoId,
                        principalTable: "GruposEconomicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Solicitacoes_TiposSolicitacao_TipoSolicitacaoId",
                        column: x => x.TipoSolicitacaoId,
                        principalTable: "TiposSolicitacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasTipoSolicitacao_GrupoEconomicoId",
                table: "CategoriasTipoSolicitacao",
                column: "GrupoEconomicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacoes_FuncionarioId",
                table: "Solicitacoes",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacoes_GrupoEconomicoId",
                table: "Solicitacoes",
                column: "GrupoEconomicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacoes_TipoSolicitacaoId",
                table: "Solicitacoes",
                column: "TipoSolicitacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposSolicitacao_CategoriaTipoSolicitacaoId",
                table: "TiposSolicitacao",
                column: "CategoriaTipoSolicitacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposSolicitacao_GrupoEconomicoId",
                table: "TiposSolicitacao",
                column: "GrupoEconomicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solicitacoes");

            migrationBuilder.DropTable(
                name: "TiposSolicitacao");

            migrationBuilder.DropTable(
                name: "CategoriasTipoSolicitacao");
        }
    }
}
