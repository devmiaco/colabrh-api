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
[Route("api/cargo")]
public class CargoController : MainController
{
    public readonly ICargoRepository _repository;
    public readonly ICargoService _service;

    public CargoController(
        INotificador notificador,
        IUser appUser,
        ICargoRepository repository,
        ICargoService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Cargo>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-grupo-economico/{id:guid}")]
    public async Task<IEnumerable<Cargo>> ObterPorGrupoEconomico(Guid id)
    {
        return await _repository.ObterPorGrupoEconomico(id);
    }

    [HttpGet("por-grade/{id:guid}")]
    public async Task<IEnumerable<Cargo>> ObterPorGrade(Guid id)
    {
        return await _repository.ObterPorGrade(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Cargo>> ObterPorId(Guid id)
    {
        var cargo = await _repository.ObterPorId(id);

        if (cargo == null) return NotFound();

        return cargo;
    }

    [HttpPost]
    public async Task<ActionResult<Cargo>> Adicionar(Cargo cargo)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(cargo);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, Cargo cargo)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != cargo.Id)
        {
            NotificarErro("Os ids informados não são iguais");
            return CustomResponse();
        }

        var atualizacao = await _repository.ObterPorId(id);

        if (atualizacao == null) return NotFound();

        atualizacao.GrupoEconomicoId = cargo.GrupoEconomicoId;
        atualizacao.GradeId = cargo.GradeId;
        atualizacao.Nome = cargo.Nome;
        atualizacao.CodigoMapeamento = cargo.CodigoMapeamento;

        await _service.Atualizar(atualizacao);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Cargo>> Excluir(Guid id)
    {
        var cargo = await _repository.ObterPorId(id);

        if (cargo == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}
