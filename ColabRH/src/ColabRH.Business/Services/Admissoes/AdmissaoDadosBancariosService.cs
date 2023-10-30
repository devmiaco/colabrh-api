using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Admissoes;
using ColabRH.Business.Models.Admissoes;
using ColabRH.Business.Validations.Admissoes;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Admissoes;

public class AdmissaoDadosBancariosService : BaseService, IAdmissaoDadosBancariosService
{
    private readonly IAdmissaoDadosBancariosRepository _repository;

    public AdmissaoDadosBancariosService(
        INotificador notificador, 
        IAdmissaoDadosBancariosRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(AdmissaoDadosBancarios admissaoDadosBancarios)
    {
        if (!ExecutarValidacao(new AdmissaoDadosBancariosValidation(), admissaoDadosBancarios)) return;

        await _repository.Adicionar(admissaoDadosBancarios);
    }

    public async Task Atualizar(AdmissaoDadosBancarios admissaoDadosBancarios)
    {
        if (!ExecutarValidacao(new AdmissaoDadosBancariosValidation(), admissaoDadosBancarios)) return;

        await _repository.Atualizar(admissaoDadosBancarios);
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
