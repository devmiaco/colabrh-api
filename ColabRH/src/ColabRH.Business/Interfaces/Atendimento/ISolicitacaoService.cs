using ColabRH.Business.Models.Atendimento;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Atendimento;

public interface ISolicitacaoService : IDisposable
{
    Task Adicionar(Solicitacao solicitacao);
    Task Atualizar(Solicitacao solicitacao);
    Task Remover(Guid id);
}
