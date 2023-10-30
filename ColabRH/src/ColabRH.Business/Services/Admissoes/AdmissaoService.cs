using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Admissoes;
using ColabRH.Business.Models.Admissoes;
using ColabRH.Business.Validations.Admissoes;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Admissoes;

public class AdmissaoService : BaseService, IAdmissaoService
{
    public readonly IAdmissaoRepository _repository;

    public AdmissaoService(
        INotificador notificador, 
        IAdmissaoRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(Admissao admissao)
    {
        if (!ExecutarValidacao(new AdmissaoValidation(), admissao)) return;

        await _repository.Adicionar(admissao);
    }

    public async Task Atualizar(Admissao admissao)
    {
        if (!ExecutarValidacao(new AdmissaoValidation(), admissao)) return;

        await _repository.Atualizar(admissao);
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
