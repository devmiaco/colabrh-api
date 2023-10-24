using ColabRH.Business.Models.Cadastros;
using System;

namespace ColabRH.Business.Models.Beneficios;

public class ContratoElegibilidadeGrade : Entity
{
    public Guid ContratoBeneficioId { get; set; }
    public Guid ContratoElegibilidadeId { get; set; }
    public Guid GradeId { get; set; }

    public Grade Grade { get; set; }
    public ContratoBeneficio ContratoBeneficio { get; set; }
    public ContratoElegibilidade ContratoElegibilidade { get; set; }
}
