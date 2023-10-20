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
[Route("api/situacao")]
public class SituacaoController : MainController
{
    public readonly ISituacaoRepository _repository;
    public readonly ISituacaoService _service;

    public SituacaoController(
        INotificador notificador,
        IUser appUser,
        ISituacaoRepository repository,
        ISituacaoService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Situacao>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-grupo-economico/{id:guid}")]
    public async Task<IEnumerable<Situacao>> ObterPorGrupoEconomico(Guid id)
    {
        return await _repository.ObterPorGrupoEconomico(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Situacao>> ObterPorId(Guid id)
    {
        var situacao = await _repository.ObterPorId(id);

        if (situacao == null) return NotFound();

        return situacao;
    }

    [HttpPost]
    public async Task<ActionResult<Grade>> Adicionar(Situacao situacao)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(situacao);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, Situacao situacao)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != situacao.Id)
        {
            NotificarErro("Os ids informados não são iguais");
            return CustomResponse();
        }

        var atualizacao = await _repository.ObterPorId(id);

        if (atualizacao == null) return NotFound();

        atualizacao.GrupoEconomicoId = situacao.GrupoEconomicoId;
        atualizacao.Nome = situacao.Nome;
        atualizacao.TipoSituacao = situacao.TipoSituacao;
        atualizacao.CodigoMapeamento = situacao.CodigoMapeamento;

        await _service.Atualizar(atualizacao);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Situacao>> Excluir(Guid id)
    {
        var situacao = await _repository.ObterPorId(id);

        if (situacao == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}
