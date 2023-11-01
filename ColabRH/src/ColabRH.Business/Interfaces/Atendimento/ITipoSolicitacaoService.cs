using ColabRH.Business.Models.Atendimento;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Atendimento;

public interface ITipoSolicitacaoService : IDisposable
{
    Task Adicionar(TipoSolicitacao tipoSolicitacao);
    Task Atualizar(TipoSolicitacao tipoSolicitacao);
    Task Remover(Guid id);
}
