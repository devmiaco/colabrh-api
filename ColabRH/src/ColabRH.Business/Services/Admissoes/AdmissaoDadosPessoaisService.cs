using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Admissoes;
using ColabRH.Business.Models.Admissoes;
using ColabRH.Business.Validations.Admissoes;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Admissoes;

public class AdmissaoDadosPessoaisService : BaseService, IAdmissaoDadosPessoaisService
{
    private readonly IAdmissaoDadosPessoaisRepository _repository;

    public AdmissaoDadosPessoaisService(
        INotificador notificador, 
        IAdmissaoDadosPessoaisRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(AdmissaoDadosPessoais admissaoDadosPessoais)
    {
        if (!ExecutarValidacao(new AdmissaoDadosPessoaisValidation(), admissaoDadosPessoais)) return;

        await _repository.Adicionar(admissaoDadosPessoais);
    }

    public async Task Atualizar(AdmissaoDadosPessoais admissaoDadosPessoais)
    {
        if (!ExecutarValidacao(new AdmissaoDadosPessoaisValidation(), admissaoDadosPessoais)) return;

        await _repository.Atualizar(admissaoDadosPessoais);
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
