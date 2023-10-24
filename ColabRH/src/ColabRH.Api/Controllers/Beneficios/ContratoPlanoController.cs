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
[Route("api/contrato-plano")]
public class ContratoPlanoController : MainController
{
    public readonly IContratoPlanoRepository _repository;
    public readonly IContratoPlanoService _service;

    public ContratoPlanoController(
        INotificador notificador,
        IUser appUser,
        IContratoPlanoRepository repository,
        IContratoPlanoService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<ContratoPlano>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-contrato/{id:guid}")]
    public async Task<IEnumerable<ContratoPlano>> ObterPorContrato(Guid id)
    {
        return await _repository.ObterPorContrato(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ContratoPlano>> ObterPorId(Guid id)
    {
        var contrato = await _repository.ObterPorId(id);

        if (contrato == null) return NotFound();

        return contrato;
    }

    [HttpPost]
    public async Task<ActionResult<ContratoPlano>> Adicionar(ContratoPlano contrato)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(contrato);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, ContratoPlano contrato)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != contrato.Id)
        {
            NotificarErro("Os ids informados não são iguais");
            return CustomResponse();
        }

        var atualizacao = await _repository.ObterPorId(id);

        if (atualizacao == null) return NotFound();

        atualizacao.PlanoId = contrato.PlanoId;
        atualizacao.Valor = contrato.Valor;
        
        await _service.Atualizar(atualizacao);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<ContratoPlano>> Excluir(Guid id)
    {
        var contrato = await _repository.ObterPorId(id);

        if (contrato == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}
