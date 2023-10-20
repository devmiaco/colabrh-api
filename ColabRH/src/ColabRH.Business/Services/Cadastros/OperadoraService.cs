using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Models.Cadastros;
using ColabRH.Business.Validations.Cadastros;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Cadastros;

public class OperadoraService : BaseService, IOperadoraService
{
    private readonly IOperadoraRepository _repository;

    public OperadoraService(
        INotificador notificador, 
        IOperadoraRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(Operadora operadora)
    {
        if (!ExecutarValidacao(new OperadoraValidation(), operadora)) return;

        await _repository.Adicionar(operadora);
    }

    public async Task Atualizar(Operadora operadora)
    {
        if (!ExecutarValidacao(new OperadoraValidation(), operadora)) return;

        await _repository.Atualizar(operadora);
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
