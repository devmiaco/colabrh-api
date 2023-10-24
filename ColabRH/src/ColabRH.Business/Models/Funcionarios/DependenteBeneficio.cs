using ColabRH.Business.Models.Enums;
using System;

namespace ColabRH.Business.Models.Funcionarios;

public class DependenteBeneficio : Entity
{
    public Guid FuncionarioBeneficioId { get; set; }
    public Guid DependenteId { get; set; }
    
    public string NumeroCartao { get; set; }
    public decimal Valor { get; set; }
    public decimal Desconto { get; set; }
    public DateTime InicioVigencia { get; set; }
    public DateTime? TerminoVigencia { get; set; }
    public TipoStatusBeneficio TipoStatus { get; set; }

    public FuncionarioBeneficio FuncionarioBeneficio { get; set; }
    public Dependente Dependente { get; set; }    
}
