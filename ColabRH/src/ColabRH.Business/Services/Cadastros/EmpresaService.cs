using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Models.Cadastros;
using ColabRH.Business.Validations.Cadastros;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Cadastros;

public class EmpresaService : BaseService, IEmpresaService
{
    private readonly IEmpresaRepository _repository;

    public EmpresaService(
        IEmpresaRepository repository,
        INotificador notificador) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(Empresa empresa)
    {
        if (!ExecutarValidacao(new EmpresaValidation(), empresa)) return;

        await _repository.Adicionar(empresa);
    }

    public async Task Atualizar(Empresa empresa)
    {
        if (!ExecutarValidacao(new EmpresaValidation(), empresa)) return;

        await _repository.Atualizar(empresa);
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
