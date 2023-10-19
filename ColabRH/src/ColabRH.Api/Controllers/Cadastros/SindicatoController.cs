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
[Route("api/sindicato")]
public class SindicatoController : MainController
{
    public readonly ISindicatoRepository _repository;
    public readonly ISindicatoService _service;

    public SindicatoController(
        INotificador notificador,
        IUser appUser,
        ISindicatoRepository repository,
        ISindicatoService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Sindicato>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-grupo-economico/{id:guid}")]
    public async Task<IEnumerable<Sindicato>> ObterPorGrupoEconomico(Guid id)
    {
        return await _repository.ObterPorGrupoEconomico(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Sindicato>> ObterPorId(Guid id)
    {
        var sindicato = await _repository.ObterPorId(id);

        if (sindicato == null) return NotFound();

        return sindicato;
    }

    [HttpPost]
    public async Task<ActionResult<Sindicato>> Adicionar(Sindicato sindicato)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(sindicato);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, Sindicato sindicato)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != sindicato.Id)
        {
            NotificarErro("Os ids informados não são iguais");
            return CustomResponse();
        }

        var atualizacao = await _repository.ObterPorId(id);

        if (atualizacao == null) return NotFound();

        atualizacao.GrupoEconomicoId = sindicato.GrupoEconomicoId;
        atualizacao.Nome = sindicato.Nome;
        atualizacao.CodigoMapeamento = sindicato.CodigoMapeamento;

        await _service.Atualizar(atualizacao);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Sindicato>> Excluir(Guid id)
    {
        var sindicato = await _repository.ObterPorId(id);

        if (sindicato == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}
