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
[Route("api/departamento")]
public class DepartamentoController : MainController
{
    public readonly IDepartamentoRepository _repository;
    public readonly IDepartamentoService _service;

    public DepartamentoController(
        INotificador notificador,
        IUser appUser,
        IDepartamentoRepository repository,
        IDepartamentoService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Departamento>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-grupo-economico/{id:guid}")]
    public async Task<IEnumerable<Departamento>> ObterPorGrupoEconomico(Guid id)
    {
        return await _repository.ObterPorGrupoEconomico(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Departamento>> ObterPorId(Guid id)
    {
        var departamento = await _repository.ObterPorId(id);

        if (departamento == null) return NotFound();

        return departamento;
    }

    [HttpPost]
    public async Task<ActionResult<Departamento>> Adicionar(Departamento grade)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(grade);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, Departamento departamento)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != departamento.Id)
        {
            NotificarErro("Os ids informados não são iguais");
            return CustomResponse();
        }

        var atualizacao = await _repository.ObterPorId(id);

        if (atualizacao == null) return NotFound();

        atualizacao.GrupoEconomicoId = departamento.GrupoEconomicoId;
        atualizacao.Nome = departamento.Nome;
        atualizacao.CodigoMapeamento = departamento.CodigoMapeamento;

        await _service.Atualizar(atualizacao);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Departamento>> Excluir(Guid id)
    {
        var departamento = await _repository.ObterPorId(id);

        if (departamento == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}
