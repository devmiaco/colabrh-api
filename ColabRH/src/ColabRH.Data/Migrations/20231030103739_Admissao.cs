using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColabRH.Data.Migrations
{
    /// <inheritdoc />
    public partial class Admissao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Municipio",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "Uf",
                table: "Empresas");

            migrationBuilder.RenameColumn(
                name: "Uf",
                table: "Funcionarios",
                newName: "DigitoConta");

            migrationBuilder.RenameColumn(
                name: "Municipio",
                table: "Funcionarios",
                newName: "Conta");

            migrationBuilder.AddColumn<string>(
                name: "Agencia",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BancoId",
                table: "Funcionarios",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ChavePix",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EstadoId",
                table: "Funcionarios",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MunicipioId",
                table: "Funcionarios",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "TipoContaBancaria",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoCorRaca",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoGenero",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoModalidadeConta",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "EstadoId",
                table: "Empresas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MunicipioId",
                table: "Empresas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "DependenteIR",
                table: "Dependentes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Pcd",
                table: "Dependentes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TipoCorRaca",
                table: "Dependentes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoGenero",
                table: "Dependentes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Universitario",
                table: "Dependentes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TipoAdesaoDependente",
                table: "ContratosElegibilidade",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoAdesaoTitular",
                table: "ContratosElegibilidade",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Admissoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoEconomicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GradeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CargoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VinculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailPessoal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataAdmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataLimitePreenchimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoStatus = table.Column<int>(type: "int", nullable: false),
                    FotoPerfil = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admissoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admissoes_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Admissoes_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Admissoes_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Admissoes_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Admissoes_GruposEconomicos_GrupoEconomicoId",
                        column: x => x.GrupoEconomicoId,
                        principalTable: "GruposEconomicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Admissoes_Vinculos_VinculoId",
                        column: x => x.VinculoId,
                        principalTable: "Vinculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Banco",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoIBGE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdmissoesDependentes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdmissaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoSexo = table.Column<int>(type: "int", nullable: false),
                    TipoGenero = table.Column<int>(type: "int", nullable: false),
                    TipoCorRaca = table.Column<int>(type: "int", nullable: false),
                    TipoEstadoCivil = table.Column<int>(type: "int", nullable: false),
                    DataCasamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NomeMae = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomePai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Peso = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Altura = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroNascidoVivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Universitario = table.Column<bool>(type: "bit", nullable: false),
                    Pcd = table.Column<bool>(type: "bit", nullable: false),
                    DependenteIR = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissoesDependentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdmissoesDependentes_Admissoes_AdmissaoId",
                        column: x => x.AdmissaoId,
                        principalTable: "Admissoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AdmissoesFormacoesAcademica",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdmissaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoEscolaridade = table.Column<int>(type: "int", nullable: false),
                    InstituicaoEnsino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Curso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnoConclusao = table.Column<int>(type: "int", nullable: false),
                    Certificado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissoesFormacoesAcademica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdmissoesFormacoesAcademica_Admissoes_AdmissaoId",
                        column: x => x.AdmissaoId,
                        principalTable: "Admissoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AdmissoesDadosBancarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdmissaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoContaBancaria = table.Column<int>(type: "int", nullable: false),
                    TipoModalidadeConta = table.Column<int>(type: "int", nullable: false),
                    BancoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Agencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Conta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DigitoConta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChavePix = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissoesDadosBancarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdmissoesDadosBancarios_Admissoes_AdmissaoId",
                        column: x => x.AdmissaoId,
                        principalTable: "Admissoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AdmissoesDadosBancarios_Banco_BancoId",
                        column: x => x.BancoId,
                        principalTable: "Banco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Municipio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoIBGE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipio_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AdmissoesDadosPessoais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdmissaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstadoNatalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MunicipioNatalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoCorRaca = table.Column<int>(type: "int", nullable: false),
                    TipoGenero = table.Column<int>(type: "int", nullable: false),
                    NomeSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoEstadoCivil = table.Column<int>(type: "int", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomeMae = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomePai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PossuiDeficiencia = table.Column<bool>(type: "bit", nullable: false),
                    TipoDeficiencia = table.Column<int>(type: "int", nullable: false),
                    ObservacaoDeficiencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissoesDadosPessoais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdmissoesDadosPessoais_Admissoes_AdmissaoId",
                        column: x => x.AdmissaoId,
                        principalTable: "Admissoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AdmissoesDadosPessoais_Estado_EstadoNatalId",
                        column: x => x.EstadoNatalId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AdmissoesDadosPessoais_Municipio_MunicipioNatalId",
                        column: x => x.MunicipioNatalId,
                        principalTable: "Municipio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AdmissoesDocumentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdmissaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RgNumero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RgDataEmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RgOrgaoEmissor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RgUFEmissorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RgFrenteComprovante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RgVersoComprovante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CnhNumero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CnhDataEmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CnhDataValidade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CnhCategoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CnhComprovante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CpfNumero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CpfComprovante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReservistaNumero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReservistaRA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReservistaCategoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReservistaComprovante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TituloEleitorNumero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TituloEleitorZonaEleitoral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TituloEleitorSecaoEleitoral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TituloEleitorEstadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TituloEleitorMunicipioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TituloEleitorComprovante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarteiraTrabalhoNumero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarteiraTrabalhoSerie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarteiraTrabalhoDataEmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarteiraTrabalhoEstadoEmissorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarteiraTrabalhoPIS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarteiraTrabalhoPrimeiraFolhaComprovante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarteiraTrabalhoSegundaFolhaComprovante = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissoesDocumentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdmissoesDocumentos_Admissoes_AdmissaoId",
                        column: x => x.AdmissaoId,
                        principalTable: "Admissoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AdmissoesDocumentos_Estado_CarteiraTrabalhoEstadoEmissorId",
                        column: x => x.CarteiraTrabalhoEstadoEmissorId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AdmissoesDocumentos_Estado_RgUFEmissorId",
                        column: x => x.RgUFEmissorId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AdmissoesDocumentos_Estado_TituloEleitorEstadoId",
                        column: x => x.TituloEleitorEstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AdmissoesDocumentos_Municipio_TituloEleitorMunicipioId",
                        column: x => x.TituloEleitorMunicipioId,
                        principalTable: "Municipio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AdmissoesEndereco",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdmissaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComprovanteResidencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefoneResidencial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefoneCelular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailPessoal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissoesEndereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdmissoesEndereco_Admissoes_AdmissaoId",
                        column: x => x.AdmissaoId,
                        principalTable: "Admissoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AdmissoesEndereco_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AdmissoesEndereco_Municipio_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_BancoId",
                table: "Funcionarios",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_EstadoId",
                table: "Funcionarios",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_MunicipioId",
                table: "Funcionarios",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_EstadoId",
                table: "Empresas",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_MunicipioId",
                table: "Empresas",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissoes_CargoId",
                table: "Admissoes",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissoes_DepartamentoId",
                table: "Admissoes",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissoes_EmpresaId",
                table: "Admissoes",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissoes_GradeId",
                table: "Admissoes",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissoes_GrupoEconomicoId",
                table: "Admissoes",
                column: "GrupoEconomicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissoes_VinculoId",
                table: "Admissoes",
                column: "VinculoId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissoesDadosBancarios_AdmissaoId",
                table: "AdmissoesDadosBancarios",
                column: "AdmissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissoesDadosBancarios_BancoId",
                table: "AdmissoesDadosBancarios",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissoesDadosPessoais_AdmissaoId",
                table: "AdmissoesDadosPessoais",
                column: "AdmissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissoesDadosPessoais_EstadoNatalId",
                table: "AdmissoesDadosPessoais",
                column: "EstadoNatalId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissoesDadosPessoais_MunicipioNatalId",
                table: "AdmissoesDadosPessoais",
                column: "MunicipioNatalId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissoesDependentes_AdmissaoId",
                table: "AdmissoesDependentes",
                column: "AdmissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissoesDocumentos_AdmissaoId",
                table: "AdmissoesDocumentos",
                column: "AdmissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissoesDocumentos_CarteiraTrabalhoEstadoEmissorId",
                table: "AdmissoesDocumentos",
                column: "CarteiraTrabalhoEstadoEmissorId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissoesDocumentos_RgUFEmissorId",
                table: "AdmissoesDocumentos",
                column: "RgUFEmissorId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissoesDocumentos_TituloEleitorEstadoId",
                table: "AdmissoesDocumentos",
                column: "TituloEleitorEstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissoesDocumentos_TituloEleitorMunicipioId",
                table: "AdmissoesDocumentos",
                column: "TituloEleitorMunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissoesEndereco_AdmissaoId",
                table: "AdmissoesEndereco",
                column: "AdmissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissoesEndereco_EstadoId",
                table: "AdmissoesEndereco",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissoesEndereco_MunicipioId",
                table: "AdmissoesEndereco",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissoesFormacoesAcademica_AdmissaoId",
                table: "AdmissoesFormacoesAcademica",
                column: "AdmissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_EstadoId",
                table: "Municipio",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Estado_EstadoId",
                table: "Empresas",
                column: "EstadoId",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Municipio_MunicipioId",
                table: "Empresas",
                column: "MunicipioId",
                principalTable: "Municipio",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Banco_BancoId",
                table: "Funcionarios",
                column: "BancoId",
                principalTable: "Banco",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Estado_EstadoId",
                table: "Funcionarios",
                column: "EstadoId",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Municipio_MunicipioId",
                table: "Funcionarios",
                column: "MunicipioId",
                principalTable: "Municipio",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Estado_EstadoId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Municipio_MunicipioId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Banco_BancoId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Estado_EstadoId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Municipio_MunicipioId",
                table: "Funcionarios");

            migrationBuilder.DropTable(
                name: "AdmissoesDadosBancarios");

            migrationBuilder.DropTable(
                name: "AdmissoesDadosPessoais");

            migrationBuilder.DropTable(
                name: "AdmissoesDependentes");

            migrationBuilder.DropTable(
                name: "AdmissoesDocumentos");

            migrationBuilder.DropTable(
                name: "AdmissoesEndereco");

            migrationBuilder.DropTable(
                name: "AdmissoesFormacoesAcademica");

            migrationBuilder.DropTable(
                name: "Banco");

            migrationBuilder.DropTable(
                name: "Municipio");

            migrationBuilder.DropTable(
                name: "Admissoes");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_BancoId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_EstadoId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_MunicipioId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_EstadoId",
                table: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_MunicipioId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "Agencia",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "BancoId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "ChavePix",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "MunicipioId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "TipoContaBancaria",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "TipoCorRaca",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "TipoGenero",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "TipoModalidadeConta",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "MunicipioId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "DependenteIR",
                table: "Dependentes");

            migrationBuilder.DropColumn(
                name: "Pcd",
                table: "Dependentes");

            migrationBuilder.DropColumn(
                name: "TipoCorRaca",
                table: "Dependentes");

            migrationBuilder.DropColumn(
                name: "TipoGenero",
                table: "Dependentes");

            migrationBuilder.DropColumn(
                name: "Universitario",
                table: "Dependentes");

            migrationBuilder.DropColumn(
                name: "TipoAdesaoDependente",
                table: "ContratosElegibilidade");

            migrationBuilder.DropColumn(
                name: "TipoAdesaoTitular",
                table: "ContratosElegibilidade");

            migrationBuilder.RenameColumn(
                name: "DigitoConta",
                table: "Funcionarios",
                newName: "Uf");

            migrationBuilder.RenameColumn(
                name: "Conta",
                table: "Funcionarios",
                newName: "Municipio");

            migrationBuilder.AddColumn<string>(
                name: "Municipio",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uf",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
