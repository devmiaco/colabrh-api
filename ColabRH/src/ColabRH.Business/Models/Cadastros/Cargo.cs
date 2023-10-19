using System;

namespace ColabRH.Business.Models.Cadastros;

public class Cargo : Entity
{
    public Guid GrupoEconomicoId { get; set; }
    public Guid? GradeId { get; set; }

    public string Nome { get; set; }
    public string CodigoMapeamento { get; set; }

    public GrupoEconomico GrupoEconomico { get; set; }
    public Grade Grade { get; set; }
}
