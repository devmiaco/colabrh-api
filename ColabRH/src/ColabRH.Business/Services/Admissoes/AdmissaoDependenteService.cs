using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Admissoes;
using ColabRH.Business.Models.Admissoes;
using ColabRH.Business.Validations.Admissoes;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Admissoes;

public class AdmissaoDependenteService : BaseService, IAdmissaoDependenteService
{
    private readonly IAdmissaoDependenteRepository _repository;

    public AdmissaoDependenteService(
        INotificador notificador, 
        IAdmissaoDependenteRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(AdmissaoDependente admissaoDependente)
    {
        if (!ExecutarValidacao(new AdmissaoDependenteValidation(), admissaoDependente)) return;

        await _repository.Adicionar(admissaoDependente);
    }

    public async Task Atualizar(AdmissaoDependente admissaoDependente)
    {
        if (!ExecutarValidacao(new AdmissaoDependenteValidation(), admissaoDependente)) return;

        await _repository.Atualizar(admissaoDependente);
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
