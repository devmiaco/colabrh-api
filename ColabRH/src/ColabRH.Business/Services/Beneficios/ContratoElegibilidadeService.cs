using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Beneficios;
using ColabRH.Business.Models.Beneficios;
using ColabRH.Business.Validations.Beneficios;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Beneficios;

public class ContratoElegibilidadeService : BaseService, IContratoElegibilidadeService
{
    private readonly IContratoElegibilidadeRepository _repository;

    public ContratoElegibilidadeService(
        INotificador notificador, 
        IContratoElegibilidadeRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(ContratoElegibilidade contratoElegibilidade)
    {
        if (!ExecutarValidacao(new ContratoElegibilidadeValidation(), contratoElegibilidade)) return;

        await _repository.Adicionar(contratoElegibilidade);
    }

    public async Task Atualizar(ContratoElegibilidade contratoElegibilidade)
    {
        if (!ExecutarValidacao(new ContratoElegibilidadeValidation(), contratoElegibilidade)) return;

        await _repository.Atualizar(contratoElegibilidade);
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
