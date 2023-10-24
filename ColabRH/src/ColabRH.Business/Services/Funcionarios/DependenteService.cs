using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Funcionarios;
using ColabRH.Business.Models.Funcionarios;
using ColabRH.Business.Validations.Funcionarios;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Funcionarios;

public class DependenteService : BaseService, IDependenteService
{
    private readonly IDependenteRepository _repository;

    public DependenteService(
        INotificador notificador, 
        IDependenteRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(Dependente dependente)
    {
        if (!ExecutarValidacao(new DependenteValidation(), dependente)) return;

        await _repository.Adicionar(dependente);
    }

    public async Task Atualizar(Dependente dependente)
    {
        if (!ExecutarValidacao(new DependenteValidation(), dependente)) return;

        await _repository.Atualizar(dependente);
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
