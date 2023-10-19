using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Models.Cadastros;
using ColabRH.Business.Validations.Cadastros;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Cadastros;

public class GrupoEconomicoService : BaseService, IGrupoEconomicoService
{
    private readonly IGrupoEconomicoRepository _repository;

    public GrupoEconomicoService(
        IGrupoEconomicoRepository repository,
        INotificador notificador) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(GrupoEconomico grupoEconomico)
    {
        if (!ExecutarValidacao(new GrupoEconomicoValidation(), grupoEconomico)) return;

        await _repository.Adicionar(grupoEconomico);
    }

    public async Task Atualizar(GrupoEconomico grupoEconomico)
    {
        if (!ExecutarValidacao(new GrupoEconomicoValidation(), grupoEconomico)) return;

        await _repository.Atualizar(grupoEconomico);
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
