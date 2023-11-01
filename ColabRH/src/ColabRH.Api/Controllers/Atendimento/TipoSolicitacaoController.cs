using ColabRH.Business.Interfaces.Atendimento;
using ColabRH.Business.Interfaces;
using ColabRH.Business.Models.Atendimento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Api.Controllers.Atendimento;

[Authorize]
[Route("api/tipo-solicitacao")]
public class TipoSolicitacaoController : MainController
{
    public readonly ITipoSolicitacaoRepository _repository;
    public readonly ITipoSolicitacaoService _service;

    public TipoSolicitacaoController(
        INotificador notificador,
        IUser appUser,
        ITipoSolicitacaoRepository repository,
        ITipoSolicitacaoService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<TipoSolicitacao>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-grupo-economico/{id:guid}")]
    public async Task<IEnumerable<TipoSolicitacao>> ObterPorGrupoEconomico(Guid id)
    {
        return await _repository.ObterPorGrupoEconomico(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TipoSolicitacao>> ObterPorId(Guid id)
    {
        var tipo = await _repository.ObterPorId(id);

        if (tipo == null) return NotFound();

        return tipo;
    }

    [HttpPost]
    public async Task<ActionResult<TipoSolicitacao>> Adicionar(TipoSolicitacao tipo)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(tipo);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, TipoSolicitacao tipo)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != tipo.Id)
        {
            NotificarErro("Os ids informados não são iguais");
            return CustomResponse();
        }

        var atualizacao = await _repository.ObterPorId(id);

        if (atualizacao == null) return NotFound();

        atualizacao.GrupoEconomicoId = tipo.GrupoEconomicoId;

        await _service.Atualizar(atualizacao);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<TipoSolicitacao>> Excluir(Guid id)
    {
        var tipo = await _repository.ObterPorId(id);

        if (tipo == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}
