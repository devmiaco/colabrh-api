using ColabRH.Business.Models.Cadastros;
using ColabRH.Business.Models.Enums;
using System;

namespace ColabRH.Business.Models.Funcionarios;

public class Dependente : Entity
{
    public Guid FuncionarioId { get; set; }
    public Guid GrauParentescoId { get; set; }
    
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
    public string Cns { get; set; }
    public string NumeroNascidoVivo { get; set; }
    
    public Funcionario Funcionario { get; set; }
    public GrauParentesco GrauParentesco { get; set; }    
}
