using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Beneficios;
using ColabRH.Business.Models.Beneficios;
using ColabRH.Business.Validations.Beneficios;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Beneficios;

public class ContratoBeneficioService : BaseService, IContratoBeneficioService
{
    private readonly IContratoBeneficioRepository _repository;

    public ContratoBeneficioService(
        INotificador notificador, 
        IContratoBeneficioRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(ContratoBeneficio contratoBeneficio)
    {
        if (!ExecutarValidacao(new ContratoBeneficioValidation(), contratoBeneficio)) return;

        await _repository.Adicionar(contratoBeneficio);
    }

    public async Task Atualizar(ContratoBeneficio contratoBeneficio)
    {
        if (!ExecutarValidacao(new ContratoBeneficioValidation(), contratoBeneficio)) return;

        await _repository.Atualizar(contratoBeneficio);
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
