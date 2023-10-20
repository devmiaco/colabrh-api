using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Beneficios;
using ColabRH.Business.Models.Beneficios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Api.Controllers.Beneficios;

[Authorize]
[Route("api/contrato-beneficio")]
public class ContratoBeneficioController : MainController
{
    public readonly IContratoBeneficioRepository _repository;
    public readonly IContratoBeneficioService _service;

    public ContratoBeneficioController(
        INotificador notificador,
        IUser appUser,
        IContratoBeneficioRepository repository,
        IContratoBeneficioService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<ContratoBeneficio>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-grupo-economico/{id:guid}")]
    public async Task<IEnumerable<ContratoBeneficio>> ObterPorGrupoEconomico(Guid id)
    {
        return await _repository.ObterPorGrupoEconomico(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ContratoBeneficio>> ObterPorId(Guid id)
    {
        var cargo = await _repository.ObterPorId(id);

        if (cargo == null) return NotFound();

        return cargo;
    }

    [HttpPost]
    public async Task<ActionResult<ContratoBeneficio>> Adicionar(ContratoBeneficio contrato)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(contrato);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, ContratoBeneficio contrato)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != contrato.Id)
        {
            NotificarErro("Os ids informados não são iguais");
            return CustomResponse();
        }

        var atualizacao = await _repository.ObterPorId(id);

        if (atualizacao == null) return NotFound();

        atualizacao.GrupoEconomicoId = contrato.GrupoEconomicoId;
        atualizacao.OperadoraId = contrato.OperadoraId;
        atualizacao.ProdutoId = contrato.ProdutoId;
        atualizacao.EmpresaId = contrato.EmpresaId;
        atualizacao.CodigoEmpresaOperadora = contrato.CodigoEmpresaOperadora;
        atualizacao.CodigoContrato = contrato.CodigoContrato;
        atualizacao.TipoCliente = contrato.TipoCliente;
        atualizacao.TipoCusteio = contrato.TipoCusteio;
        atualizacao.DataInicioVigencia = contrato.DataInicioVigencia;
        atualizacao.DataTerminoVigencia = contrato.DataTerminoVigencia;
        atualizacao.TempoVigencia = contrato.TempoVigencia;
        atualizacao.DataAniversario = contrato.DataAniversario;
        atualizacao.DataInicioOperacao = contrato.DataInicioOperacao;
        atualizacao.TipoNegocio = contrato.TipoNegocio;
        atualizacao.DiaCorte = contrato.DiaCorte;
        atualizacao.DiaLiberacaoFatura = contrato.DiaLiberacaoFatura;
        atualizacao.DiaVencimentoFatura = contrato.DiaVencimentoFatura;
        atualizacao.DependenteMaiorIdade = contrato.DependenteMaiorIdade;
        atualizacao.DependenteUniversitarioIdade = contrato.DependenteUniversitarioIdade;

        await _service.Atualizar(atualizacao);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<ContratoBeneficio>> Excluir(Guid id)
    {
        var contrato = await _repository.ObterPorId(id);

        if (contrato == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}
