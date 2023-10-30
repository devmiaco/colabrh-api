using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Admissoes;
using ColabRH.Business.Models.Admissoes;
using ColabRH.Business.Validations.Admissoes;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Admissoes;

public class AdmissaoFormacaoAcademicaService : BaseService, IAdmissaoFormacaoAcademicaService
{
    private readonly IAdmissaoFormacaoAcademicaRepository _repository;

    public AdmissaoFormacaoAcademicaService(
        INotificador notificador,
        IAdmissaoFormacaoAcademicaRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(AdmissaoFormacaoAcademica admissaoFormacaoAcademica)
    {
        if (!ExecutarValidacao(new AdmissaoFormacaoAcademicaValidation(), admissaoFormacaoAcademica)) return;

        await _repository.Adicionar(admissaoFormacaoAcademica);
    }

    public async Task Atualizar(AdmissaoFormacaoAcademica admissaoFormacaoAcademica)
    {
        if (!ExecutarValidacao(new AdmissaoFormacaoAcademicaValidation(), admissaoFormacaoAcademica)) return;

        await _repository.Atualizar(admissaoFormacaoAcademica);
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
