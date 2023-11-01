using ColabRH.Business.Models.Cadastros;
using System;

namespace ColabRH.Business.Models.Atendimento;

public class TipoSolicitacao : Entity
{
    public Guid GrupoEconomicoId { get; set; }
    public Guid CategoriaTipoSolicitacaoId { get; set; }

    public string Nome { get; set; }
    public bool Ativo { get; set; }

    public GrupoEconomico GrupoEconomico { get; set; }
    public CategoriaTipoSolicitacao CategoriaTipoSolicitacao { get; set; }
}
