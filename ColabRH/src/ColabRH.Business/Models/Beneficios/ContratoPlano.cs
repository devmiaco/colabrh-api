using ColabRH.Business.Models.Cadastros;
using System;

namespace ColabRH.Business.Models.Beneficios;

public class ContratoPlano : Entity
{
    public Guid ContratoBeneficioId { get; set; }
    public Guid PlanoId { get; set; }

    public decimal Valor { get; set; }

    public ContratoBeneficio ContratoBeneficio { get; set; }
    public Plano Plano { get; set; }
}
