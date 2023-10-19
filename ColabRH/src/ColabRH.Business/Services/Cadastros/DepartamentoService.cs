using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Models.Cadastros;
using ColabRH.Business.Validations.Cadastros;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Cadastros;

public class DepartamentoService : BaseService, IDepartamentoService
{
    private readonly IDepartamentoRepository _repository;
    public DepartamentoService(
        INotificador notificador, 
        IDepartamentoRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(Departamento departamento)
    {
        if (!ExecutarValidacao(new DepartamentoValidation(), departamento)) return;

        await _repository.Adicionar(departamento);
    }

    public async Task Atualizar(Departamento departamento)
    {
        if (!ExecutarValidacao(new DepartamentoValidation(), departamento)) return;

        await _repository.Atualizar(departamento);
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
