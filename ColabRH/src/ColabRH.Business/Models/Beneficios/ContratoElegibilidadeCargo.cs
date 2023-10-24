using ColabRH.Business.Models.Cadastros;
using System;

namespace ColabRH.Business.Models.Beneficios;

public class ContratoElegibilidadeCargo : Entity
{
    public Guid ContratoBeneficioId { get; set; }
    public Guid ContratoElegibilidadeId { get; set; }
    public Guid CargoId { get; set; }

    public Cargo Cargo { get; set; }
    public ContratoBeneficio ContratoBeneficio { get; set; }
    public ContratoElegibilidade ContratoElegibilidade { get; set; }
}
