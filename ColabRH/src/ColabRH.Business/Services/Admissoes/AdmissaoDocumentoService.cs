using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Admissoes;
using ColabRH.Business.Models.Admissoes;
using ColabRH.Business.Validations.Admissoes;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Admissoes;

public class AdmissaoDocumentoService : BaseService, IAdmissaoDocumentoService
{
    private readonly IAdmissaoDocumentoRepository _repository;

    public AdmissaoDocumentoService(
        INotificador notificador, 
        IAdmissaoDocumentoRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(AdmissaoDocumento admissaoDocumento)
    {
        if (!ExecutarValidacao(new AdmissaoDocumentoValidation(), admissaoDocumento)) return;

        await _repository.Adicionar(admissaoDocumento);
    }

    public async Task Atualizar(AdmissaoDocumento admissaoDocumento)
    {
        if (!ExecutarValidacao(new AdmissaoDocumentoValidation(), admissaoDocumento)) return;

        await _repository.Atualizar(admissaoDocumento);
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
