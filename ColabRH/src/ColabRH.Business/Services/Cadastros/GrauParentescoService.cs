using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Models.Cadastros;
using ColabRH.Business.Validations.Cadastros;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Cadastros;

public class GrauParentescoService : BaseService, IGrauParentescoService
{
    private readonly IGrauParentescoRepository _repository;

    public GrauParentescoService(
        INotificador notificador, 
        IGrauParentescoRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(GrauParentesco grauParentesco)
    {
        if (!ExecutarValidacao(new GrauParentescoValidation(), grauParentesco)) return;

        await _repository.Adicionar(grauParentesco);
    }

    public async Task Atualizar(GrauParentesco grauParentesco)
    {
        if (!ExecutarValidacao(new GrauParentescoValidation(), grauParentesco)) return;

        await _repository.Atualizar(grauParentesco);
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
