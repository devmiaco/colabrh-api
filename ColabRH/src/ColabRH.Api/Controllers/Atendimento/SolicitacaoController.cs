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
[Route("api/solicitacao")]
public class SolicitacaoController : MainController
{
    public readonly ISolicitacaoRepository _repository;
    public readonly ISolicitacaoService _service;

    public SolicitacaoController(
        INotificador notificador,
        IUser appUser,
        ISolicitacaoRepository repository,
        ISolicitacaoService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Solicitacao>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-tipo/{id:guid}")]
    public async Task<IEnumerable<Solicitacao>> ObterPorTipo(Guid id)
    {
        return await _repository.ObterPorTipo(id);
    }

    [HttpGet("por-funcionario/{id:guid}")]
    public async Task<IEnumerable<Solicitacao>> ObterPorFuncionario(Guid id)
    {
        return await _repository.ObterPorFuncionario(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Solicitacao>> ObterPorId(Guid id)
    {
        var categoria = await _repository.ObterPorId(id);

        if (categoria == null) return NotFound();

        return categoria;
    }

    [HttpPost]
    public async Task<ActionResult<Solicitacao>> Adicionar(Solicitacao solicitacao)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(solicitacao);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, Solicitacao solicitacao)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != solicitacao.Id)
        {
            NotificarErro("Os ids informados não são iguais");
            return CustomResponse();
        }

        var atualizacao = await _repository.ObterPorId(id);

        if (atualizacao == null) return NotFound();

        atualizacao.GrupoEconomicoId = solicitacao.GrupoEconomicoId;

        await _service.Atualizar(atualizacao);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Solicitacao>> Excluir(Guid id)
    {
        var solicitacao = await _repository.ObterPorId(id);

        if (solicitacao == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}
