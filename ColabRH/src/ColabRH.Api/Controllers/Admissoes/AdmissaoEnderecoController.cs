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
[Route("api/admissao-endereco")]
public class AdmissaoEnderecoController : MainController
{
    public readonly IAdmissaoEnderecoRepository _repository;
    public readonly IAdmissaoEnderecoService _service;

    public AdmissaoEnderecoController(
        INotificador notificador,
        IUser appUser,
        IAdmissaoEnderecoRepository repository,
        IAdmissaoEnderecoService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<AdmissaoEndereco>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-admissao/{id:guid}")]
    public async Task<AdmissaoEndereco> ObterPorGrupoEconomico(Guid id)
    {
        return await _repository.ObterPorAdmissao(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AdmissaoEndereco>> ObterPorId(Guid id)
    {
        var admissao = await _repository.ObterPorId(id);

        if (admissao == null) return NotFound();

        return admissao;
    }

    [HttpPost]
    public async Task<ActionResult<AdmissaoEndereco>> Adicionar(AdmissaoEndereco admissao)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(admissao);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, AdmissaoEndereco admissao)
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
    public async Task<ActionResult<AdmissaoEndereco>> Excluir(Guid id)
    {
        var admissao = await _repository.ObterPorId(id);

        if (admissao == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}
