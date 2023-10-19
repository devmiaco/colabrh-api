using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Models.Cadastros;
using ColabRH.Business.Validations.Cadastros;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Cadastros;

public class CargoService : BaseService, ICargoService
{
    private readonly ICargoRepository _repository;

    public CargoService(
        INotificador notificador, 
        ICargoRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(Cargo cargo)
    {
        if (!ExecutarValidacao(new CargoValidation(), cargo)) return;

        await _repository.Adicionar(cargo);
    }

    public async Task Atualizar(Cargo cargo)
    {
        if (!ExecutarValidacao(new CargoValidation(), cargo)) return;

        await _repository.Atualizar(cargo);
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
