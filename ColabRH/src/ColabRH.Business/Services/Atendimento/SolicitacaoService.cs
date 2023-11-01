using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Atendimento;
using ColabRH.Business.Models.Atendimento;
using ColabRH.Business.Validations.Atendimento;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Atendimento;

public class SolicitacaoService : BaseService, ISolicitacaoService
{
    private readonly ISolicitacaoRepository _repository;

    public SolicitacaoService(
        INotificador notificador, 
        ISolicitacaoRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(Solicitacao solicitacao)
    {
        if (!ExecutarValidacao(new SolicitacaoValidation(), solicitacao)) return;

        await _repository.Adicionar(solicitacao);
    }

    public async Task Atualizar(Solicitacao solicitacao)
    {
        if (!ExecutarValidacao(new SolicitacaoValidation(), solicitacao)) return;

        await _repository.Atualizar(solicitacao);
    }    

    public async Task Remover(Guid id)
    {
        await _repository.Remover(id);
    }

    public void Dispose()
    {
        _repository?.Dispose();
    }
}
