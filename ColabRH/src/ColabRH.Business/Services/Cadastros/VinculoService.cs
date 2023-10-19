using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Models.Cadastros;
using ColabRH.Business.Validations.Cadastros;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Cadastros;

public class VinculoService : BaseService, IVinculoService
{
    private readonly IVinculoRepository _repository;

    public VinculoService(
        INotificador notificador, 
        IVinculoRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(Vinculo vinculo)
    {
        if (!ExecutarValidacao(new VinculoValidation(), vinculo)) return;

        await _repository.Adicionar(vinculo);
    }

    public async Task Atualizar(Vinculo vinculo)
    {
        if (!ExecutarValidacao(new VinculoValidation(), vinculo)) return;

        await _repository.Atualizar(vinculo);
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
