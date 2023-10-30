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
[Route("api/admissao-dados-pessoais")]
public class AdmissaoDadosPessoaisController : MainController
{
    public readonly IAdmissaoDadosPessoaisRepository _repository;
    public readonly IAdmissaoDadosPessoaisService _service;

    public AdmissaoDadosPessoaisController(
        INotificador notificador, 
        IUser appUser,
        IAdmissaoDadosPessoaisRepository repository,
        IAdmissaoDadosPessoaisService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<AdmissaoDadosPessoais>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-admissao/{id:guid}")]
    public async Task<AdmissaoDadosPessoais> ObterPorGrupoEconomico(Guid id)
    {
        return await _repository.ObterPorAdmissao(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AdmissaoDadosPessoais>> ObterPorId(Guid id)
    {
        var admissao = await _repository.ObterPorId(id);

        if (admissao == null) return NotFound();

        return admissao;
    }

    [HttpPost]
    public async Task<ActionResult<AdmissaoDadosPessoais>> Adicionar(AdmissaoDadosPessoais admissao)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(admissao);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, AdmissaoDadosPessoais admissao)
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
    public async Task<ActionResult<AdmissaoDadosPessoais>> Excluir(Guid id)
    {
        var admissao = await _repository.ObterPorId(id);

        if (admissao == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}
