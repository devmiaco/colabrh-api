using ColabRH.Business.Models.Enums;
using System;
using System.Collections.Generic;

namespace ColabRH.Business.Models.Cadastros;

public class Situacao : Entity
{
    public Guid GrupoEconomicoId { get; set; }

    public string Nome { get; set; }
    public TipoSituacao TipoSituacao { get; set; }
    public string CodigoMapeamento { get; set; }

    public GrupoEconomico GrupoEconomico { get; set; }    
}
