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
[Route("api/contrato-elegibilidade")]
public class ContratoElegibilidadeController : MainController
{
    public readonly IContratoElegibilidadeRepository _repository;
    public readonly IContratoElegibilidadeService _service;

    public ContratoElegibilidadeController(
        INotificador notificador,
        IUser appUser,
        IContratoElegibilidadeRepository repository,
        IContratoElegibilidadeService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<ContratoElegibilidade>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-contrato/{id:guid}")]
    public async Task<IEnumerable<ContratoElegibilidade>> ObterPorContrato(Guid id)
    {
        return await _repository.ObterPorContrato(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ContratoElegibilidade>> ObterPorId(Guid id)
    {
        var contrato = await _repository.ObterPorId(id);

        if (contrato == null) return NotFound();

        return contrato;
    }

    [HttpPost]
    public async Task<ActionResult<ContratoElegibilidade>> Adicionar(ContratoElegibilidade contrato)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(contrato);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, ContratoElegibilidade contrato)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != contrato.Id)
        {
            NotificarErro("Os ids informados não são iguais");
            return CustomResponse();
        }

        var atualizacao = await _repository.ObterPorId(id);

        if (atualizacao == null) return NotFound();

        atualizacao.Nome = contrato.Nome;
        atualizacao.TipoContribuicaoTitular = contrato.TipoContribuicaoTitular;
        atualizacao.ValorTitular = contrato.ValorTitular;
        atualizacao.TipoContribuicaoDependente = contrato.TipoContribuicaoDependente;
        atualizacao.ValorDependente = contrato.ValorDependente;

        await _service.Atualizar(atualizacao);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<ContratoElegibilidade>> Excluir(Guid id)
    {
        var contrato = await _repository.ObterPorId(id);

        if (contrato == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}