using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Interfaces;
using ColabRH.Business.Models.Cadastros;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace ColabRH.Api.Controllers.Cadastros;

[Authorize]
[Route("api/plano")]
public class PlanoController : MainController
{
    public readonly IPlanoRepository _repository;
    public readonly IPlanoService _service;

    public PlanoController(INotificador notificador,
        IUser appUser,
        IPlanoRepository repository,
        IPlanoService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Plano>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-produto/{id:guid}")]
    public async Task<IEnumerable<Plano>> ObterPorProduto(Guid id)
    {
        return await _repository.ObterPorProduto(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Plano>> ObterPorId(Guid id)
    {
        var plano = await _repository.ObterPorId(id);

        if (plano == null) return NotFound();

        return plano;
    }

    [HttpPost]
    public async Task<ActionResult<Plano>> Adicionar(Plano plano)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(plano);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, Plano plano)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != plano.Id)
        {
            NotificarErro("Os ids informados não são iguais");
            return CustomResponse();
        }

        var atualizacao = await _repository.ObterPorId(id);

        if (atualizacao == null) return NotFound();

        atualizacao.OperadoraId = plano.OperadoraId;
        atualizacao.ProdutoId = plano.ProdutoId;
        atualizacao.Nome = plano.Nome;
        atualizacao.Codigo = plano.Codigo;
        atualizacao.TipoAcomodacao = plano.TipoAcomodacao;
        atualizacao.TipoAbrangencia = plano.TipoAbrangencia;
        atualizacao.Descricao = plano.Descricao;

        await _service.Atualizar(atualizacao);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Plano>> Excluir(Guid id)
    {
        var plano = await _repository.ObterPorId(id);

        if (plano == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}
