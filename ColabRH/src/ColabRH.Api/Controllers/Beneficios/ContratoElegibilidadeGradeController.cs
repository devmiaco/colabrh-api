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
[Route("api/contrato-elegibilidade-grade")]
public class ContratoElegibilidadeGradeController : MainController
{
    public readonly IContratoElegibilidadeGradeRepository _repository;
    public readonly IContratoElegibilidadeGradeService _service;

    public ContratoElegibilidadeGradeController(
        INotificador notificador,
        IUser appUser,
        IContratoElegibilidadeGradeRepository repository,
        IContratoElegibilidadeGradeService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<ContratoElegibilidadeGrade>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-contrato-elegibilidade/{id:guid}")]
    public async Task<IEnumerable<ContratoElegibilidadeGrade>> ObterPorContratoElegibilidade(Guid id)
    {
        return await _repository.ObterPorContratoElegibilidade(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ContratoElegibilidadeGrade>> ObterPorId(Guid id)
    {
        var contrato = await _repository.ObterPorId(id);

        if (contrato == null) return NotFound();

        return contrato;
    }

    [HttpPost]
    public async Task<ActionResult<ContratoElegibilidade>> Adicionar(ContratoElegibilidadeGrade contrato)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(contrato);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, ContratoElegibilidadeGrade contrato)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != contrato.Id)
        {
            NotificarErro("Os ids informados não são iguais");
            return CustomResponse();
        }

        var atualizacao = await _repository.ObterPorId(id);

        if (atualizacao == null) return NotFound();

        atualizacao.GradeId = contrato.GradeId;
        
        await _service.Atualizar(atualizacao);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<ContratoElegibilidadeGrade>> Excluir(Guid id)
    {
        var contrato = await _repository.ObterPorId(id);

        if (contrato == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }

}
