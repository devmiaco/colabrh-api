using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Beneficios;
using ColabRH.Business.Models.Beneficios;
using ColabRH.Business.Validations.Beneficios;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Beneficios;

public class ContratoGrauParentescoService : BaseService, IContratoGrauParentescoService
{
    private readonly IContratoGrauParentescoRepository _repository;

    public ContratoGrauParentescoService(
        INotificador notificador, 
        IContratoGrauParentescoRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(ContratoGrauParentesco contratoGrauParentesco)
    {
        if (!ExecutarValidacao(new ContratoGrauParentescoValidation(), contratoGrauParentesco)) return;

        await _repository.Adicionar(contratoGrauParentesco);
    }

    public async Task Atualizar(ContratoGrauParentesco contratoGrauParentesco)
    {
        if (!ExecutarValidacao(new ContratoGrauParentescoValidation(), contratoGrauParentesco)) return;

        await _repository.Atualizar(contratoGrauParentesco);
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
