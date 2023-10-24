using System;

namespace ColabRH.Business.Models.Beneficios;

public class ContratoSubestipulante : Entity
{
    public Guid ContratoBeneficioId { get; set; }

    public string CodigoEmpresaOperadora { get; set; }
    public bool Ativo { get; set; }

    public ContratoBeneficio ContratoBeneficio { get; set; }
}
