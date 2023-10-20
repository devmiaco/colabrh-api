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
[Route("api/produto")]
public class ProdutoController : MainController
{
    public readonly IProdutoRepository _repository;
    public readonly IProdutoService _service;

    public ProdutoController(INotificador notificador,
        IUser appUser,
        IProdutoRepository repository,
        IProdutoService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Produto>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-operadora/{id:guid}")]
    public async Task<IEnumerable<Produto>> ObterPorOperadora(Guid id)
    {
        return await _repository.ObterPorOperadora(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Produto>> ObterPorId(Guid id)
    {
        var produto = await _repository.ObterPorId(id);

        if (produto == null) return NotFound();

        return produto;
    }

    [HttpPost]
    public async Task<ActionResult<Operadora>> Adicionar(Produto produto)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(produto);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, Produto produto)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != produto.Id)
        {
            NotificarErro("Os ids informados não são iguais");
            return CustomResponse();
        }

        var atualizacao = await _repository.ObterPorId(id);

        if (atualizacao == null) return NotFound();

        atualizacao.OperadoraId = produto.OperadoraId;
        atualizacao.Nome = produto.Nome;
        atualizacao.TipoProduto = produto.TipoProduto;

        await _service.Atualizar(atualizacao);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Operadora>> Excluir(Guid id)
    {
        var produto = await _repository.ObterPorId(id);

        if (produto == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}
