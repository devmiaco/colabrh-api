using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Models.Cadastros;
using ColabRH.Business.Validations.Cadastros;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Cadastros;

public class PlanoService : BaseService, IPlanoService
{
    private readonly IPlanoRepository _repository;

    public PlanoService(
        INotificador notificador, 
        IPlanoRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(Plano plano)
    {
        if (!ExecutarValidacao(new PlanoValidation(), plano)) return;

        await _repository.Adicionar(plano);
    }

    public async Task Atualizar(Plano plano)
    {
        if (!ExecutarValidacao(new PlanoValidation(), plano)) return;

        await _repository.Atualizar(plano);
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
