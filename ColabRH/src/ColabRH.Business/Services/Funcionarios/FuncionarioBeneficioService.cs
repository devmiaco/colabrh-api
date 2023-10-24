using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Funcionarios;
using ColabRH.Business.Models.Funcionarios;
using ColabRH.Business.Validations.Funcionarios;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Funcionarios;

public class FuncionarioBeneficioService : BaseService, IFuncionarioBeneficioService
{
    private readonly IFuncionarioBeneficioRepository _repository;

    public FuncionarioBeneficioService(
        INotificador notificador, 
        IFuncionarioBeneficioRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(FuncionarioBeneficio funcionarioBeneficio)
    {
        if (!ExecutarValidacao(new FuncionarioBeneficioValidation(), funcionarioBeneficio)) return;

        await _repository.Adicionar(funcionarioBeneficio);
    }

    public async Task Atualizar(FuncionarioBeneficio funcionarioBeneficio)
    {
        if (!ExecutarValidacao(new FuncionarioBeneficioValidation(), funcionarioBeneficio)) return;

        await _repository.Atualizar(funcionarioBeneficio);
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
