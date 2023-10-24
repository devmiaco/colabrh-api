using ColabRH.Business.Models.Beneficios;
using ColabRH.Business.Models.Cadastros;
using ColabRH.Business.Models.Enums;
using System;

namespace ColabRH.Business.Models.Funcionarios;

public class FuncionarioBeneficio : Entity
{
    public Guid FuncionarioId { get; set; }
    public Guid OperadoraId { get; set; }
    public Guid ProdutoId { get; set; }
    public Guid ContratoBeneficioId { get; set; }
    public Guid ContratoPlanoId { get; set; }

    public string NumeroCartao { get; set; }
    public decimal Valor { get; set; }
    public decimal Desconto { get; set; }
    public DateTime InicioVigencia { get; set; }
    public DateTime? TerminoVigencia { get; set; }
    public TipoStatusBeneficio TipoStatus { get; set; }

    public Funcionario Funcionario { get; set; }
    public Operadora Operadora { get; set; }
    public Produto Produto { get; set; }
    public ContratoBeneficio ContratoBeneficio { get; set; }
    public ContratoPlano ContratoPlano { get; set; }
}
