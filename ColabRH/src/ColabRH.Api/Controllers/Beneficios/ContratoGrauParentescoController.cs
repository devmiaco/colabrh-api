using ColabRH.Business.Interfaces.Beneficios;
using ColabRH.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;
using ColabRH.Business.Models.Beneficios;

namespace ColabRH.Api.Controllers.Beneficios;

[Authorize]
[Route("api/contrato-grau-parentesco")]
public class ContratoGrauParentescoController : MainController
{
    public readonly IContratoGrauParentescoRepository _repository;
    public readonly IContratoGrauParentescoService _service;

    public ContratoGrauParentescoController(
        INotificador notificador,
        IUser appUser,
        IContratoGrauParentescoRepository repository,
        IContratoGrauParentescoService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<ContratoGrauParentesco>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-contrato/{id:guid}")]
    public async Task<IEnumerable<ContratoGrauParentesco>> ObterPorContrato(Guid id)
    {
        return await _repository.ObterPorContrato(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ContratoGrauParentesco>> ObterPorId(Guid id)
    {
        var contrato = await _repository.ObterPorId(id);

        if (contrato == null) return NotFound();

        return contrato;
    }

    [HttpPost]
    public async Task<ActionResult<ContratoGrauParentesco>> Adicionar(ContratoGrauParentesco contrato)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(contrato);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, ContratoGrauParentesco contrato)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != contrato.Id)
        {
            NotificarErro("Os ids informados não são iguais");
            return CustomResponse();
        }

        var atualizacao = await _repository.ObterPorId(id);

        if (atualizacao == null) return NotFound();

        atualizacao.GrauParentescoId = contrato.GrauParentescoId;        

        await _service.Atualizar(atualizacao);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<ContratoGrauParentesco>> Excluir(Guid id)
    {
        var contrato = await _repository.ObterPorId(id);

        if (contrato == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}
