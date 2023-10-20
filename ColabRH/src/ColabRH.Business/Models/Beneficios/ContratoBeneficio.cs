using ColabRH.Business.Models.Cadastros;
using ColabRH.Business.Models.Enums;
using System;

namespace ColabRH.Business.Models.Beneficios;

public class ContratoBeneficio : Entity
{
    public Guid GrupoEconomicoId { get; set; }
    public Guid OperadoraId { get; set; }
    public Guid ProdutoId { get; set; }
    public Guid EmpresaId { get; set; }

    public string CodigoEmpresaOperadora { get; set; }
    public string CodigoContrato { get; set; }
    public TipoClienteContrato TipoCliente { get; set; }
    public TipoCusteioContrato TipoCusteio { get; set; }
    public DateTime DataInicioVigencia { get; set; }
    public DateTime DataTerminoVigencia { get; set; }
    public int TempoVigencia { get; set; }
    public DateTime DataAniversario { get; set; }
    public DateTime DataInicioOperacao { get; set; }
    public TipoNegocioContrato TipoNegocio { get; set; }
    public int DiaCorte { get; set; }
    public int DiaLiberacaoFatura { get; set; }
    public int DiaVencimentoFatura { get; set; }
    public int DependenteMaiorIdade { get; set; }
    public int DependenteUniversitarioIdade { get; set; }

    public GrupoEconomico GrupoEconomico { get; set; }
    public Operadora Operadora { get; set; }
    public Produto Produto { get; set; }
    public Empresa Empresa { get; set; }
}
