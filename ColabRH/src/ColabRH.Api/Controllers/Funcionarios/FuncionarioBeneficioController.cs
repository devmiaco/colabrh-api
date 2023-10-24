using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Funcionarios;
using ColabRH.Business.Models.Funcionarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Api.Controllers.Funcionarios;

[Authorize]
[Route("api/funcionario-beneficio")]
public class FuncionarioBeneficioController : MainController
{
    public readonly IFuncionarioBeneficioRepository _repository;
    public readonly IFuncionarioBeneficioService _service;

    public FuncionarioBeneficioController(
        INotificador notificador,
        IUser appUser,
        IFuncionarioBeneficioRepository repository,
        IFuncionarioBeneficioService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<FuncionarioBeneficio>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-funcionario/{id:guid}")]
    public async Task<IEnumerable<FuncionarioBeneficio>> ObterPorFuncionario(Guid id)
    {
        return await _repository.ObterPorFuncionario(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<FuncionarioBeneficio>> ObterPorId(Guid id)
    {
        var funcionarioBeneficio = await _repository.ObterPorId(id);

        if (funcionarioBeneficio == null) return NotFound();

        return funcionarioBeneficio;
    }

    [HttpPost]
    public async Task<ActionResult<FuncionarioBeneficio>> Adicionar(FuncionarioBeneficio funcionarioBeneficio)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(funcionarioBeneficio);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, FuncionarioBeneficio funcionarioBeneficio)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != funcionarioBeneficio.Id)
        {
            NotificarErro("Os ids informados não são iguais");
            return CustomResponse();
        }

        var atualizacao = await _repository.ObterPorId(id);

        if (atualizacao == null) return NotFound();

        atualizacao.NumeroCartao = funcionarioBeneficio.NumeroCartao;
        atualizacao.Valor = funcionarioBeneficio.Valor;
        atualizacao.Desconto = funcionarioBeneficio.Desconto;
        atualizacao.InicioVigencia = funcionarioBeneficio.InicioVigencia;
        atualizacao.TerminoVigencia = funcionarioBeneficio.TerminoVigencia ;
        atualizacao.TipoStatus = funcionarioBeneficio.TipoStatus;
        
        await _service.Atualizar(atualizacao);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<FuncionarioBeneficio>> Excluir(Guid id)
    {
        var funcionarioBeneficio = await _repository.ObterPorId(id);

        if (funcionarioBeneficio == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}
