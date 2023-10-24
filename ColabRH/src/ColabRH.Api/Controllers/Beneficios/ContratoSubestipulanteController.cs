using ColabRH.Business.Interfaces.Beneficios;
using ColabRH.Business.Interfaces;
using ColabRH.Business.Models.Beneficios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace ColabRH.Api.Controllers.Beneficios;

[Authorize]
[Route("api/contrato-subestipulante")]
public class ContratoSubestipulanteController : MainController
{
    public readonly IContratoSubestipulanteRepository _repository;
    public readonly IContratoSubestipulanteService _service;

    public ContratoSubestipulanteController(
        INotificador notificador,
        IUser appUser,
        IContratoSubestipulanteRepository repository,
        IContratoSubestipulanteService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<ContratoSubestipulante>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-contrato/{id:guid}")]
    public async Task<IEnumerable<ContratoSubestipulante>> ObterPorContrato(Guid id)
    {
        return await _repository.ObterPorContrato(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ContratoSubestipulante>> ObterPorId(Guid id)
    {
        var contrato = await _repository.ObterPorId(id);

        if (contrato == null) return NotFound();

        return contrato;
    }

    [HttpPost]
    public async Task<ActionResult<ContratoSubestipulante>> Adicionar(ContratoSubestipulante contrato)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(contrato);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, ContratoSubestipulante contrato)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != contrato.Id)
        {
            NotificarErro("Os ids informados não são iguais");
            return CustomResponse();
        }

        var atualizacao = await _repository.ObterPorId(id);

        if (atualizacao == null) return NotFound();

        atualizacao.CodigoEmpresaOperadora = contrato.CodigoEmpresaOperadora;
        atualizacao.Ativo = contrato.Ativo;        

        await _service.Atualizar(atualizacao);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<ContratoSubestipulante>> Excluir(Guid id)
    {
        var contrato = await _repository.ObterPorId(id);

        if (contrato == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}
