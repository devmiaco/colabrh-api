using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColabRH.Data.Migrations
{
    /// <inheritdoc />
    public partial class EstadoMunicipio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdmissoesDadosPessoais_Estado_EstadoNatalId",
                table: "AdmissoesDadosPessoais");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissoesDadosPessoais_Municipio_MunicipioNatalId",
                table: "AdmissoesDadosPessoais");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissoesDocumentos_Estado_CarteiraTrabalhoEstadoEmissorId",
                table: "AdmissoesDocumentos");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissoesDocumentos_Estado_RgUFEmissorId",
                table: "AdmissoesDocumentos");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissoesDocumentos_Estado_TituloEleitorEstadoId",
                table: "AdmissoesDocumentos");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissoesDocumentos_Municipio_TituloEleitorMunicipioId",
                table: "AdmissoesDocumentos");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissoesEndereco_Estado_EstadoId",
                table: "AdmissoesEndereco");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissoesEndereco_Municipio_MunicipioId",
                table: "AdmissoesEndereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Estado_EstadoId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Municipio_MunicipioId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Estado_EstadoId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Municipio_MunicipioId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Municipio_Estado_EstadoId",
                table: "Municipio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Municipio",
                table: "Municipio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estado",
                table: "Estado");

            migrationBuilder.RenameTable(
                name: "Municipio",
                newName: "Municipios");

            migrationBuilder.RenameTable(
                name: "Estado",
                newName: "Estados");

            migrationBuilder.RenameIndex(
                name: "IX_Municipio_EstadoId",
                table: "Municipios",
                newName: "IX_Municipios_EstadoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Municipios",
                table: "Municipios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estados",
                table: "Estados",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissoesDadosPessoais_Estados_EstadoNatalId",
                table: "AdmissoesDadosPessoais",
                column: "EstadoNatalId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissoesDadosPessoais_Municipios_MunicipioNatalId",
                table: "AdmissoesDadosPessoais",
                column: "MunicipioNatalId",
                principalTable: "Municipios",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissoesDocumentos_Estados_CarteiraTrabalhoEstadoEmissorId",
                table: "AdmissoesDocumentos",
                column: "CarteiraTrabalhoEstadoEmissorId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissoesDocumentos_Estados_RgUFEmissorId",
                table: "AdmissoesDocumentos",
                column: "RgUFEmissorId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissoesDocumentos_Estados_TituloEleitorEstadoId",
                table: "AdmissoesDocumentos",
                column: "TituloEleitorEstadoId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissoesDocumentos_Municipios_TituloEleitorMunicipioId",
                table: "AdmissoesDocumentos",
                column: "TituloEleitorMunicipioId",
                principalTable: "Municipios",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissoesEndereco_Estados_EstadoId",
                table: "AdmissoesEndereco",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissoesEndereco_Municipios_MunicipioId",
                table: "AdmissoesEndereco",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Estados_EstadoId",
                table: "Empresas",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Municipios_MunicipioId",
                table: "Empresas",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Estados_EstadoId",
                table: "Funcionarios",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Municipios_MunicipioId",
                table: "Funcionarios",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Municipios_Estados_EstadoId",
                table: "Municipios",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdmissoesDadosPessoais_Estados_EstadoNatalId",
                table: "AdmissoesDadosPessoais");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissoesDadosPessoais_Municipios_MunicipioNatalId",
                table: "AdmissoesDadosPessoais");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissoesDocumentos_Estados_CarteiraTrabalhoEstadoEmissorId",
                table: "AdmissoesDocumentos");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissoesDocumentos_Estados_RgUFEmissorId",
                table: "AdmissoesDocumentos");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissoesDocumentos_Estados_TituloEleitorEstadoId",
                table: "AdmissoesDocumentos");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissoesDocumentos_Municipios_TituloEleitorMunicipioId",
                table: "AdmissoesDocumentos");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissoesEndereco_Estados_EstadoId",
                table: "AdmissoesEndereco");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissoesEndereco_Municipios_MunicipioId",
                table: "AdmissoesEndereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Estados_EstadoId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Municipios_MunicipioId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Estados_EstadoId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Municipios_MunicipioId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Municipios_Estados_EstadoId",
                table: "Municipios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Municipios",
                table: "Municipios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estados",
                table: "Estados");

            migrationBuilder.RenameTable(
                name: "Municipios",
                newName: "Municipio");

            migrationBuilder.RenameTable(
                name: "Estados",
                newName: "Estado");

            migrationBuilder.RenameIndex(
                name: "IX_Municipios_EstadoId",
                table: "Municipio",
                newName: "IX_Municipio_EstadoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Municipio",
                table: "Municipio",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estado",
                table: "Estado",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissoesDadosPessoais_Estado_EstadoNatalId",
                table: "AdmissoesDadosPessoais",
                column: "EstadoNatalId",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissoesDadosPessoais_Municipio_MunicipioNatalId",
                table: "AdmissoesDadosPessoais",
                column: "MunicipioNatalId",
                principalTable: "Municipio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissoesDocumentos_Estado_CarteiraTrabalhoEstadoEmissorId",
                table: "AdmissoesDocumentos",
                column: "CarteiraTrabalhoEstadoEmissorId",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissoesDocumentos_Estado_RgUFEmissorId",
                table: "AdmissoesDocumentos",
                column: "RgUFEmissorId",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissoesDocumentos_Estado_TituloEleitorEstadoId",
                table: "AdmissoesDocumentos",
                column: "TituloEleitorEstadoId",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissoesDocumentos_Municipio_TituloEleitorMunicipioId",
                table: "AdmissoesDocumentos",
                column: "TituloEleitorMunicipioId",
                principalTable: "Municipio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissoesEndereco_Estado_EstadoId",
                table: "AdmissoesEndereco",
                column: "EstadoId",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissoesEndereco_Municipio_MunicipioId",
                table: "AdmissoesEndereco",
                column: "MunicipioId",
                principalTable: "Municipio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Estado_EstadoId",
                table: "Empresas",
                column: "EstadoId",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Municipio_MunicipioId",
                table: "Empresas",
                column: "MunicipioId",
                principalTable: "Municipio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Estado_EstadoId",
                table: "Funcionarios",
                column: "EstadoId",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Municipio_MunicipioId",
                table: "Funcionarios",
                column: "MunicipioId",
                principalTable: "Municipio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Municipio_Estado_EstadoId",
                table: "Municipio",
                column: "EstadoId",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
