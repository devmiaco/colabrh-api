using ColabRH.Business.Interfaces.Funcionarios;
using ColabRH.Business.Interfaces;
using ColabRH.Business.Models.Funcionarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace ColabRH.Api.Controllers.Funcionarios;

[Authorize]
[Route("api/dependente-beneficio")]
public class DependenteBeneficioController : MainController
{
    public readonly IDependenteBeneficioRepository _repository;
    public readonly IDependenteBeneficioService _service;

    public DependenteBeneficioController(
        INotificador notificador,
        IUser appUser,
        IDependenteBeneficioRepository repository,
        IDependenteBeneficioService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<DependenteBeneficio>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-dependente/{id:guid}")]
    public async Task<IEnumerable<DependenteBeneficio>> ObterPorDependente(Guid id)
    {
        return await _repository.ObterPorDependente(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<DependenteBeneficio>> ObterPorId(Guid id)
    {
        var dependenteBeneficio = await _repository.ObterPorId(id);

        if (dependenteBeneficio == null) return NotFound();

        return dependenteBeneficio;
    }

    [HttpPost]
    public async Task<ActionResult<DependenteBeneficio>> Adicionar(DependenteBeneficio dependenteBeneficio)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(dependenteBeneficio);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, DependenteBeneficio dependenteBeneficio)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != dependenteBeneficio.Id)
        {
            NotificarErro("Os ids informados não são iguais");
            return CustomResponse();
        }

        var atualizacao = await _repository.ObterPorId(id);

        if (atualizacao == null) return NotFound();

        atualizacao.NumeroCartao = dependenteBeneficio.NumeroCartao;
        atualizacao.Valor = dependenteBeneficio.Valor;
        atualizacao.Desconto = dependenteBeneficio.Desconto;
        atualizacao.InicioVigencia = dependenteBeneficio.InicioVigencia;
        atualizacao.TerminoVigencia = dependenteBeneficio.TerminoVigencia;
        atualizacao.TipoStatus = dependenteBeneficio.TipoStatus;

        await _service.Atualizar(atualizacao);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<DependenteBeneficio>> Excluir(Guid id)
    {
        var dependenteBeneficio = await _repository.ObterPorId(id);

        if (dependenteBeneficio == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}
