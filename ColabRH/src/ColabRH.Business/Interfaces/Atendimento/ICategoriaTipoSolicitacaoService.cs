using ColabRH.Business.Models.Atendimento;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Atendimento;

public interface ICategoriaTipoSolicitacaoService : IDisposable
{
    Task Adicionar(CategoriaTipoSolicitacao categoriaTipoSolicitacao);
    Task Atualizar(CategoriaTipoSolicitacao categoriaTipoSolicitacao);
    Task Remover(Guid id);
}
