using ColabRH.Business.Models.Enums;
using System;

namespace ColabRH.Business.Models.Beneficios;

public class ContratoElegibilidade : Entity
{
    public Guid ContratoBeneficioId { get; set; }

    public string Nome { get; set; }
    public TipoAdesaoContrato TipoAdesaoTitular { get; set; }
    public TipoContribuicaoContrato TipoContribuicaoTitular { get; set; }
    public decimal ValorTitular { get; set; }
    public TipoAdesaoContrato TipoAdesaoDependente { get; set; }
    public TipoContribuicaoContrato TipoContribuicaoDependente { get; set; }
    public decimal ValorDependente { get; set; }

    public ContratoBeneficio ContratoBeneficio { get; set; }
}
