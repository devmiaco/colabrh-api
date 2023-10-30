using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Admissoes;
using ColabRH.Business.Models.Admissoes;
using ColabRH.Business.Validations.Admissoes;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Admissoes;

public class AdmissaoEnderecoService : BaseService, IAdmissaoEnderecoService
{
    private readonly IAdmissaoEnderecoRepository _repository;

    public AdmissaoEnderecoService(
        INotificador notificador, 
        IAdmissaoEnderecoRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(AdmissaoEndereco admissaoEndereco)
    {
        if (!ExecutarValidacao(new AdmissaoEnderecoValidation(), admissaoEndereco)) return;

        await _repository.Adicionar(admissaoEndereco);
    }

    public async Task Atualizar(AdmissaoEndereco admissaoEndereco)
    {
        if (!ExecutarValidacao(new AdmissaoEnderecoValidation(), admissaoEndereco)) return;

        await _repository.Atualizar(admissaoEndereco);
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
