using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Models.Cadastros;
using ColabRH.Business.Validations.Cadastros;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Cadastros;

public class SituacaoService : BaseService, ISituacaoService
{
    private readonly ISituacaoRepository _repository;

    public SituacaoService(
        INotificador notificador, 
        ISituacaoRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(Situacao situacao)
    {
        if (!ExecutarValidacao(new SituacaoValidation(), situacao)) return;

        await _repository.Adicionar(situacao);
    }

    public async Task Atualizar(Situacao situacao)
    {
        if (!ExecutarValidacao(new SituacaoValidation(), situacao)) return;

        await _repository.Atualizar(situacao);
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
