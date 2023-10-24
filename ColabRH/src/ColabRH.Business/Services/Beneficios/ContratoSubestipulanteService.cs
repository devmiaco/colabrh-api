using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Beneficios;
using ColabRH.Business.Models.Beneficios;
using ColabRH.Business.Validations.Beneficios;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Beneficios;

public class ContratoSubestipulanteService : BaseService, IContratoSubestipulanteService
{
    private readonly IContratoSubestipulanteRepository _repository;

    public ContratoSubestipulanteService(
        INotificador notificador, 
        IContratoSubestipulanteRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(ContratoSubestipulante contratoSubestipulante)
    {
        if (!ExecutarValidacao(new ContratoSubestipulanteValidation(), contratoSubestipulante)) return;

        await _repository.Adicionar(contratoSubestipulante);
    }

    public async Task Atualizar(ContratoSubestipulante contratoSubestipulante)
    {
        if (!ExecutarValidacao(new ContratoSubestipulanteValidation(), contratoSubestipulante)) return;

        await _repository.Atualizar(contratoSubestipulante);
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
