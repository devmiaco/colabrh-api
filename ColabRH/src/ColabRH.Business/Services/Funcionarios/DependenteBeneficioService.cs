using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Funcionarios;
using ColabRH.Business.Models.Funcionarios;
using ColabRH.Business.Validations.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Funcionarios;

public class DependenteBeneficioService : BaseService, IDependenteBeneficioService
{
    private readonly IDependenteBeneficioRepository _repository;

    public DependenteBeneficioService(
        INotificador notificador, 
        IDependenteBeneficioRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(DependenteBeneficio dependenteBeneficio)
    {
        if (!ExecutarValidacao(new DependenteBeneficioValidation(), dependenteBeneficio)) return;

        await _repository.Adicionar(dependenteBeneficio);
    }

    public async Task Atualizar(DependenteBeneficio dependenteBeneficio)
    {
        if (!ExecutarValidacao(new DependenteBeneficioValidation(), dependenteBeneficio)) return;

        await _repository.Atualizar(dependenteBeneficio);
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
