using ColabRH.Business.Models.Cadastros;
using System;

namespace ColabRH.Business.Models.Atendimento;

public class CategoriaTipoSolicitacao : Entity
{
    public Guid GrupoEconomicoId { get; set; }
    public string Nome { get; set; }
    public bool Ativo { get; set; }

    public GrupoEconomico GrupoEconomico { get; set; }
}
