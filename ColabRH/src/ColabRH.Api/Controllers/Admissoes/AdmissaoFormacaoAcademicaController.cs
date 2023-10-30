using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Admissoes;
using ColabRH.Business.Models.Admissoes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Api.Controllers.Admissoes;

[Authorize]
[Route("api/admissao-formacao-academica")]
public class AdmissaoFormacaoAcademicaController : MainController
{
    public readonly IAdmissaoFormacaoAcademicaRepository _repository;
    public readonly IAdmissaoFormacaoAcademicaService _service;

    public AdmissaoFormacaoAcademicaController(
        INotificador notificador,
        IUser appUser,
        IAdmissaoFormacaoAcademicaRepository repository,
        IAdmissaoFormacaoAcademicaService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<AdmissaoFormacaoAcademica>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-admissao/{id:guid}")]
    public async Task<IEnumerable<AdmissaoFormacaoAcademica>> ObterPorGrupoEconomico(Guid id)
    {
        return await _repository.ObterPorAdmissao(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AdmissaoFormacaoAcademica>> ObterPorId(Guid id)
    {
        var admissao = await _repository.ObterPorId(id);

        if (admissao == null) return NotFound();

        return admissao;
    }

    [HttpPost]
    public async Task<ActionResult<AdmissaoFormacaoAcademica>> Adicionar(AdmissaoFormacaoAcademica admissao)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(admissao);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, AdmissaoFormacaoAcademica admissao)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != admissao.Id)
        {
            NotificarErro("Os ids informados não são iguais");
            return CustomResponse();
        }

        var atualizacao = await _repository.ObterPorId(id);

        if (atualizacao == null) return NotFound();

        //atualizacao.GrupoEconomicoId = admissao.GrupoEconomicoId;

        await _service.Atualizar(atualizacao);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<AdmissaoFormacaoAcademica>> Excluir(Guid id)
    {
        var admissao = await _repository.ObterPorId(id);

        if (admissao == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}
