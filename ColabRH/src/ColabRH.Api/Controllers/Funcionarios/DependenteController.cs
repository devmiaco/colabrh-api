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
[Route("api/dependente")]
public class DependenteController : MainController
{
    public readonly IDependenteRepository _repository;
    public readonly IDependenteService _service;

    public DependenteController(
        INotificador notificador,
        IUser appUser,
        IDependenteRepository repository,
        IDependenteService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Dependente>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-funcionario/{id:guid}")]
    public async Task<IEnumerable<Dependente>> ObterPorFuncionario(Guid id)
    {
        return await _repository.ObterPorFuncionario(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Dependente>> ObterPorId(Guid id)
    {
        var dependente = await _repository.ObterPorId(id);

        if (dependente == null) return NotFound();

        return dependente;
    }

    [HttpPost]
    public async Task<ActionResult<Dependente>> Adicionar(Dependente dependente)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(dependente);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, Dependente dependente)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != dependente.Id)
        {
            NotificarErro("Os ids informados não são iguais");
            return CustomResponse();
        }

        var atualizacao = await _repository.ObterPorId(id);

        if (atualizacao == null) return NotFound();

        atualizacao.GrauParentescoId = dependente.GrauParentescoId;
        atualizacao.Nome = dependente.Nome;
        atualizacao.DataNascimento = dependente.DataNascimento;
        atualizacao.TipoSexo = dependente.TipoSexo;
        atualizacao.TipoEstadoCivil = dependente.TipoEstadoCivil;
        atualizacao.DataCasamento = dependente.DataCasamento;
        atualizacao.NomeMae = dependente.NomeMae;
        atualizacao.NomePai = dependente.NomePai;
        atualizacao.Peso = dependente.Peso;
        atualizacao.Altura = dependente.Altura;
        atualizacao.Cpf = dependente.Cpf;
        atualizacao.Rg = dependente.Rg;
        atualizacao.Cns = dependente.Cns;
        atualizacao.NumeroNascidoVivo = dependente.NumeroNascidoVivo;

        await _service.Atualizar(atualizacao);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Dependente>> Excluir(Guid id)
    {
        var dependente = await _repository.ObterPorId(id);

        if (dependente == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}
