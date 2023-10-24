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
[Route("api/contrato-elegibilidade-cargo")]
public class ContratoElegibilidadeCargoController : MainController
{
    public readonly IContratoElegibilidadeCargoRepository _repository;
    public readonly IContratoElegibilidadeCargoService _service;

    public ContratoElegibilidadeCargoController(
        INotificador notificador,
        IUser appUser,
        IContratoElegibilidadeCargoRepository repository,
        IContratoElegibilidadeCargoService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<ContratoElegibilidadeCargo>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-contrato-elegibilidade/{id:guid}")]
    public async Task<IEnumerable<ContratoElegibilidadeCargo>> ObterPorContratoElegibilidade(Guid id)
    {
        return await _repository.ObterPorContratoElegibilidade(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ContratoElegibilidadeCargo>> ObterPorId(Guid id)
    {
        var contrato = await _repository.ObterPorId(id);

        if (contrato == null) return NotFound();

        return contrato;
    }

    [HttpPost]
    public async Task<ActionResult<ContratoElegibilidadeCargo>> Adicionar(ContratoElegibilidadeCargo contrato)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(contrato);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, ContratoElegibilidadeCargo contrato)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != contrato.Id)
        {
            NotificarErro("Os ids informados não são iguais");
            return CustomResponse();
        }

        var atualizacao = await _repository.ObterPorId(id);

        if (atualizacao == null) return NotFound();

        atualizacao.CargoId = contrato.CargoId;

        await _service.Atualizar(atualizacao);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<ContratoElegibilidadeCargo>> Excluir(Guid id)
    {
        var contrato = await _repository.ObterPorId(id);

        if (contrato == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}

