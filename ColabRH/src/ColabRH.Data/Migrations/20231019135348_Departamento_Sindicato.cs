using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColabRH.Data.Migrations
{
    /// <inheritdoc />
    public partial class Departamento_Sindicato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoEconomicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoMapeamento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamentos_GruposEconomicos_GrupoEconomicoId",
                        column: x => x.GrupoEconomicoId,
                        principalTable: "GruposEconomicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sindicatos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoEconomicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoMapeamento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sindicatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sindicatos_GruposEconomicos_GrupoEconomicoId",
                        column: x => x.GrupoEconomicoId,
                        principalTable: "GruposEconomicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_GrupoEconomicoId",
                table: "Departamentos",
                column: "GrupoEconomicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Sindicatos_GrupoEconomicoId",
                table: "Sindicatos",
                column: "GrupoEconomicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Sindicatos");
        }
    }
}
