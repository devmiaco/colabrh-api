using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Models.Cadastros;
using ColabRH.Business.Validations.Cadastros;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Cadastros;

public class SindicatoService : BaseService, ISindicatoService
{
    private readonly ISindicatoRepository _repository;

    public SindicatoService(
        INotificador notificador, 
        ISindicatoRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(Sindicato sindicato)
    {
        if (!ExecutarValidacao(new SindicatoValidation(), sindicato)) return;

        await _repository.Adicionar(sindicato);
    }

    public async Task Atualizar(Sindicato sindicato)
    {
        if (!ExecutarValidacao(new SindicatoValidation(), sindicato)) return;

        await _repository.Atualizar(sindicato);
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
