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
[Route("api/operadora")]
public class OperadoraController : MainController
{
    public readonly IOperadoraRepository _repository;
    public readonly IOperadoraService _service;

    public OperadoraController(INotificador notificador,
        IUser appUser,
        IOperadoraRepository repository,
        IOperadoraService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Operadora>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-grupo-economico/{id:guid}")]
    public async Task<IEnumerable<Operadora>> ObterPorGrupoEconomico(Guid id)
    {
        return await _repository.ObterPorGrupoEconomico(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Operadora>> ObterPorId(Guid id)
    {
        var grade = await _repository.ObterPorId(id);

        if (grade == null) return NotFound();

        return grade;
    }

    [HttpPost]
    public async Task<ActionResult<Operadora>> Adicionar(Operadora operadora)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(operadora);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, Operadora operadora)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != operadora.Id)
        {
            NotificarErro("Os ids informados não são iguais");
            return CustomResponse();
        }

        var atualizacao = await _repository.ObterPorId(id);

        if (atualizacao == null) return NotFound();

        atualizacao.GrupoEconomicoId = operadora.GrupoEconomicoId;
        atualizacao.Cnpj = operadora.Cnpj;
        atualizacao.Nome = operadora.Nome;        
        atualizacao.Telefone = operadora.Telefone;

        await _service.Atualizar(atualizacao);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Operadora>> Excluir(Guid id)
    {
        var operadora = await _repository.ObterPorId(id);

        if (operadora == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}
