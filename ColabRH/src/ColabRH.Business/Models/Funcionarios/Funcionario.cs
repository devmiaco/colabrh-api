using ColabRH.Business.Models.Cadastros;
using ColabRH.Business.Models.Enums;
using System;

namespace ColabRH.Business.Models.Funcionarios;

public class Funcionario : Entity
{
    public Guid GrupoEconomicoId { get; set; }
    public Guid EmpresaId { get; set; }
    public Guid? GradeId { get; set; }
    public Guid CargoId { get; set; }
    public Guid DepartamentoId { get; set; }
    public Guid? SindicatoId { get; set; }
    public Guid VinculoId { get; set; }
    public Guid SituacaoId { get; set; }


    public string Matricula { get; set; }
    public DateTime DataAdmissao { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public TipoSexo TipoSexo { get; set; }
    public TipoEstadoCivil TipoEstadoCivil { get; set; }
    public DateTime? DataCasamento { get; set; }
    public string NomeMae { get; set; }
    public string NomePai { get; set; }
    public decimal Peso { get; set; }
    public decimal Altura { get; set; }
    public string Cpf { get; set; }
    public string Rg { get; set; }
    public string TelefoneFixo { get; set; }
    public string TelefoneCelular { get; set; }
    public string EmailPessoal { get; set; }
    public string EmailCorporativo { get; set; }
    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Municipio { get; set; }
    public string Uf { get; set; }


    public GrupoEconomico GrupoEconomico { get; set; }
    public Empresa Empresa { get; set; }
    public Grade Grade { get; set; }
    public Cargo Cargo { get; set; }
    public Departamento Departamento { get; set; }
    public Sindicato Sindicato { get; set; }
    public Vinculo Vinculo { get; set; }
    public Situacao Situacao { get; set; }
}
