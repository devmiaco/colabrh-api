using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Funcionarios;
using ColabRH.Business.Models.Funcionarios;
using ColabRH.Business.Validations.Funcionarios;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Funcionarios;

public class FuncionarioService : BaseService, IFuncionarioService
{
    private readonly IFuncionarioRepository _repository;

    public FuncionarioService(
        INotificador notificador, 
        IFuncionarioRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(Funcionario funcionario)
    {
        if (!ExecutarValidacao(new FuncionarioValidation(), funcionario)) return;

        await _repository.Adicionar(funcionario);
    }

    public async Task Atualizar(Funcionario funcionario)
    {
        if (!ExecutarValidacao(new FuncionarioValidation(), funcionario)) return;

        await _repository.Atualizar(funcionario);
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
