using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Interfaces;
using ColabRH.Business.Models.Cadastros;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace ColabRH.Api.Controllers.Cadastros;

[Authorize]
[Route("api/grau-parentesco")]
public class GrauParentescoController : MainController
{
    public readonly IGrauParentescoRepository _repository;
    public readonly IGrauParentescoService _service;

    public GrauParentescoController(
        INotificador notificador,
        IUser appUser,
        IGrauParentescoRepository repository,
        IGrauParentescoService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<GrauParentesco>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-grupo-economico/{id:guid}")]
    public async Task<IEnumerable<GrauParentesco>> ObterPorGrupoEconomico(Guid id)
    {
        return await _repository.ObterPorGrupoEconomico(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GrauParentesco>> ObterPorId(Guid id)
    {
        var grauParentesco = await _repository.ObterPorId(id);

        if (grauParentesco == null) return NotFound();

        return grauParentesco;
    }

    [HttpPost]
    public async Task<ActionResult<Grade>> Adicionar(GrauParentesco grauParentesco)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(grauParentesco);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, GrauParentesco grauParentesco)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != grauParentesco.Id)
        {
            NotificarErro("Os ids informados não são iguais");
            return CustomResponse();
        }

        var atualizacao = await _repository.ObterPorId(id);

        if (atualizacao == null) return NotFound();

        atualizacao.GrupoEconomicoId = grauParentesco.GrupoEconomicoId;
        atualizacao.Nome = grauParentesco.Nome;
        atualizacao.TipoGrauParentesco = grauParentesco.TipoGrauParentesco;
        atualizacao.CodigoMapeamento = grauParentesco.CodigoMapeamento;

        await _service.Atualizar(atualizacao);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<GrauParentesco>> Excluir(Guid id)
    {
        var grauParentesco = await _repository.ObterPorId(id);

        if (grauParentesco == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}
