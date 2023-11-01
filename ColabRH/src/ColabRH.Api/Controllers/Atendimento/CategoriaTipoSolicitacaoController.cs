using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Atendimento;
using ColabRH.Business.Models.Atendimento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Api.Controllers.Atendimento;

[Authorize]
[Route("api/categoria-tipo-solicitacao")]
public class CategoriaTipoSolicitacaoController : MainController
{
    public readonly ICategoriaTipoSolicitacaoRepository _repository;
    public readonly ICategoriaTipoSolicitacaoService _service;

    public CategoriaTipoSolicitacaoController(
        INotificador notificador,
        IUser appUser,
        ICategoriaTipoSolicitacaoRepository repository,
        ICategoriaTipoSolicitacaoService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<CategoriaTipoSolicitacao>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-grupo-economico/{id:guid}")]
    public async Task<IEnumerable<CategoriaTipoSolicitacao>> ObterPorGrupoEconomico(Guid id)
    {
        return await _repository.ObterPorGrupoEconomico(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CategoriaTipoSolicitacao>> ObterPorId(Guid id)
    {
        var categoria = await _repository.ObterPorId(id);

        if (categoria == null) return NotFound();

        return categoria;
    }

    [HttpPost]
    public async Task<ActionResult<CategoriaTipoSolicitacao>> Adicionar(CategoriaTipoSolicitacao categoria)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(categoria);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, CategoriaTipoSolicitacao categoria)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != categoria.Id)
        {
            NotificarErro("Os ids informados não são iguais");
            return CustomResponse();
        }

        var atualizacao = await _repository.ObterPorId(id);

        if (atualizacao == null) return NotFound();

        atualizacao.GrupoEconomicoId = categoria.GrupoEconomicoId;

        await _service.Atualizar(atualizacao);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<CategoriaTipoSolicitacao>> Excluir(Guid id)
    {
        var categoria = await _repository.ObterPorId(id);

        if (categoria == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}
