using ColabRH.Business.Models.Cadastros;
using System;

namespace ColabRH.Business.Models.Beneficios;

public class ContratoGrauParentesco : Entity
{
    public Guid ContratoBeneficioId { get; set; }
    public Guid GrauParentescoId { get; set; }

    public ContratoBeneficio ContratoBeneficio { get; set; }
    public GrauParentesco GrauParentesco { get; set; }
}
