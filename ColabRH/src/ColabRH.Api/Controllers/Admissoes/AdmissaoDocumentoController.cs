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
[Route("api/admissao-documento")]
public class AdmissaoDocumentoController : MainController
{
    public readonly IAdmissaoDocumentoRepository _repository;
    public readonly IAdmissaoDocumentoService _service;

    public AdmissaoDocumentoController(
        INotificador notificador,
        IUser appUser,
        IAdmissaoDocumentoRepository repository,
        IAdmissaoDocumentoService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<AdmissaoDocumento>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-admissao/{id:guid}")]
    public async Task<AdmissaoDocumento> ObterPorGrupoEconomico(Guid id)
    {
        return await _repository.ObterPorAdmissao(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AdmissaoDocumento>> ObterPorId(Guid id)
    {
        var admissao = await _repository.ObterPorId(id);

        if (admissao == null) return NotFound();

        return admissao;
    }

    [HttpPost]
    public async Task<ActionResult<AdmissaoDocumento>> Adicionar(AdmissaoDocumento admissao)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(admissao);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, AdmissaoDocumento admissao)
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
    public async Task<ActionResult<AdmissaoDocumento>> Excluir(Guid id)
    {
        var admissao = await _repository.ObterPorId(id);

        if (admissao == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}
