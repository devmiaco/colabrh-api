using ColabRH.Business.Models.Enums;
using System;

namespace ColabRH.Business.Models.Cadastros;

public class GrauParentesco : Entity
{
    public Guid GrupoEconomicoId { get; set; }

    public string Nome { get; set; }
    public TipoGrauParentesco TipoGrauParentesco { get; set; }
    public string CodigoMapeamento { get; set; }

    public GrupoEconomico GrupoEconomico { get; set; }
}
