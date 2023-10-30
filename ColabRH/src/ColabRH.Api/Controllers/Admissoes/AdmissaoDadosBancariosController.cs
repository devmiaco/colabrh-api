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
[Route("api/admissao-dados-bancarios")]
public class AdmissaoDadosBancariosController : MainController
{
    public readonly IAdmissaoDadosBancariosRepository _repository;
    public readonly IAdmissaoDadosBancariosService _service;

    public AdmissaoDadosBancariosController(
        INotificador notificador,
        IUser appUser,
        IAdmissaoDadosBancariosRepository repository,
        IAdmissaoDadosBancariosService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<AdmissaoDadosBancarios>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-admissao/{id:guid}")]
    public async Task<AdmissaoDadosBancarios> ObterPorGrupoEconomico(Guid id)
    {
        return await _repository.ObterPorAdmissao(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AdmissaoDadosBancarios>> ObterPorId(Guid id)
    {
        var admissao = await _repository.ObterPorId(id);

        if (admissao == null) return NotFound();

        return admissao;
    }

    [HttpPost]
    public async Task<ActionResult<AdmissaoDadosBancarios>> Adicionar(AdmissaoDadosBancarios admissao)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(admissao);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, AdmissaoDadosBancarios admissao)
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
    public async Task<ActionResult<AdmissaoDadosBancarios>> Excluir(Guid id)
    {
        var admissao = await _repository.ObterPorId(id);

        if (admissao == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}
