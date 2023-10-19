using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Models.Cadastros;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Api.Controllers.Cadastros;

[Authorize]
[Route("api/grupo-economico")]
public class GrupoEconomicoController : MainController
{
    public readonly IGrupoEconomicoRepository _repository;
    public readonly IGrupoEconomicoService _service;

    public GrupoEconomicoController(
        INotificador notificador, 
        IUser appUser,
        IGrupoEconomicoRepository repository,
        IGrupoEconomicoService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<GrupoEconomico>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("ativos")]
    public async Task<IEnumerable<GrupoEconomico>> ObterAtivos()
    {
        return await _repository.ObterAtivos();
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GrupoEconomico>> ObterPorId(Guid id)
    {
        var grupo = await _repository.ObterPorId(id);

        if (grupo == null) return NotFound();

        return grupo;
    }

    [HttpPost]
    public async Task<ActionResult<GrupoEconomico>> Adicionar(GrupoEconomico grupo)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(grupo);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, GrupoEconomico grupo)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != grupo.Id)
        {
            NotificarErro("Os ids informados não são iguais");
            return CustomResponse();
        }

        var atualizacao = await _repository.ObterPorId(id);

        if (atualizacao == null) return NotFound();

        atualizacao.Nome = grupo.Nome;
        atualizacao.Ativo = grupo.Ativo;

        await _service.Atualizar(atualizacao);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<GrupoEconomico>> Excluir(Guid id)
    {
        var grupo = await _repository.ObterPorId(id);

        if (grupo == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}
