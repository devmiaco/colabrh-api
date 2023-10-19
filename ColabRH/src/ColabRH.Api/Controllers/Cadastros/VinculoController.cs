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
[Route("api/vinculo")]
public class VinculoController : MainController
{
    public readonly IVinculoRepository _repository;
    public readonly IVinculoService _service;

    public VinculoController(
        INotificador notificador,
        IUser appUser,
        IVinculoRepository repository,
        IVinculoService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Vinculo>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-grupo-economico/{id:guid}")]
    public async Task<IEnumerable<Vinculo>> ObterPorGrupoEconomico(Guid id)
    {
        return await _repository.ObterPorGrupoEconomico(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Vinculo>> ObterPorId(Guid id)
    {
        var vinculo = await _repository.ObterPorId(id);

        if (vinculo == null) return NotFound();

        return vinculo;
    }

    [HttpPost]
    public async Task<ActionResult<Vinculo>> Adicionar(Vinculo vinculo)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(vinculo);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, Vinculo vinculo)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != vinculo.Id)
        {
            NotificarErro("Os ids informados não são iguais");
            return CustomResponse();
        }

        var atualizacao = await _repository.ObterPorId(id);

        if (atualizacao == null) return NotFound();

        atualizacao.GrupoEconomicoId = vinculo.GrupoEconomicoId;
        atualizacao.Nome = vinculo.Nome;
        atualizacao.CodigoMapeamento = vinculo.CodigoMapeamento;

        await _service.Atualizar(atualizacao);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Vinculo>> Excluir(Guid id)
    {
        var vinculo = await _repository.ObterPorId(id);

        if (vinculo == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}
