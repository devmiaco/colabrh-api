using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Beneficios;
using ColabRH.Business.Models.Beneficios;
using ColabRH.Business.Validations.Beneficios;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Beneficios;

public class ContratoPlanoService : BaseService, IContratoPlanoService
{
    private readonly IContratoPlanoRepository _repository;

    public ContratoPlanoService(
        INotificador notificador, 
        IContratoPlanoRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(ContratoPlano contratoPlano)
    {
        if (!ExecutarValidacao(new ContratoPlanoValidation(), contratoPlano)) return;

        await _repository.Adicionar(contratoPlano);
    }

    public async Task Atualizar(ContratoPlano contratoPlano)
    {
        if (!ExecutarValidacao(new ContratoPlanoValidation(), contratoPlano)) return;

        await _repository.Atualizar(contratoPlano);
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
