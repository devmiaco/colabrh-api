using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Atendimento;
using ColabRH.Business.Models.Atendimento;
using ColabRH.Business.Validations.Atendimento;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Atendimento;

public class TipoSolicitacaoService : BaseService, ITipoSolicitacaoService
{
    private readonly ITipoSolicitacaoRepository _repository;

    public TipoSolicitacaoService(
        INotificador notificador, 
        ITipoSolicitacaoRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(TipoSolicitacao tipoSolicitacao)
    {
        if (!ExecutarValidacao(new TipoSolicitacaoValidation(), tipoSolicitacao)) return;

        await _repository.Adicionar(tipoSolicitacao);
    }

    public async Task Atualizar(TipoSolicitacao tipoSolicitacao)
    {
        if (!ExecutarValidacao(new TipoSolicitacaoValidation(), tipoSolicitacao)) return;

        await _repository.Atualizar(tipoSolicitacao);
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
