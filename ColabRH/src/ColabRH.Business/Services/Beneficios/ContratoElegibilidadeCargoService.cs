using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Beneficios;
using ColabRH.Business.Models.Beneficios;
using ColabRH.Business.Validations.Beneficios;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Beneficios;

public class ContratoElegibilidadeCargoService : BaseService, IContratoElegibilidadeCargoService
{
    private readonly IContratoElegibilidadeCargoRepository _repository;

    public ContratoElegibilidadeCargoService(
        INotificador notificador, 
        IContratoElegibilidadeCargoRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(ContratoElegibilidadeCargo contratoElegibilidadeCargo)
    {
        if (!ExecutarValidacao(new ContratoElegibilidadeCargoValidation(), contratoElegibilidadeCargo)) return;

        await _repository.Adicionar(contratoElegibilidadeCargo);
    }

    public async Task Atualizar(ContratoElegibilidadeCargo contratoElegibilidadeCargo)
    {
        if (!ExecutarValidacao(new ContratoElegibilidadeCargoValidation(), contratoElegibilidadeCargo)) return;

        await _repository.Atualizar(contratoElegibilidadeCargo);
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
