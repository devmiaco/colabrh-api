using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ColabRH.Business.Models.Cadastros;

namespace ColabRH.Api.Controllers.Cadastros;

[Authorize]
[Route("api/grade")]
public class GradeController : MainController
{
    public readonly IGradeRepository _repository;
    public readonly IGradeService _service;

    public GradeController(
        INotificador notificador,
        IUser appUser,
        IGradeRepository repository,
        IGradeService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Grade>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-grupo-economico/{id:guid}")]
    public async Task<IEnumerable<Grade>> ObterPorGrupoEconomico(Guid id)
    {
        return await _repository.ObterPorGrupoEconomico(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Grade>> ObterPorId(Guid id)
    {
        var grade = await _repository.ObterPorId(id);

        if (grade == null) return NotFound();

        return grade;
    }

    [HttpPost]
    public async Task<ActionResult<Grade>> Adicionar(Grade grade)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(grade);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, Grade grade)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != grade.Id)
        {
            NotificarErro("Os ids informados não são iguais");
            return CustomResponse();
        }

        var atualizacao = await _repository.ObterPorId(id);

        if (atualizacao == null) return NotFound();

        atualizacao.GrupoEconomicoId = grade.GrupoEconomicoId;
        atualizacao.Nome = grade.Nome;
        atualizacao.CodigoMapeamento = grade.CodigoMapeamento;

        await _service.Atualizar(atualizacao);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Grade>> Excluir(Guid id)
    {
        var grade = await _repository.ObterPorId(id);

        if (grade == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}
