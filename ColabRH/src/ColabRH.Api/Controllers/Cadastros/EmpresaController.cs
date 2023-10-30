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
[Route("api/empresa")]
public class EmpresaController : MainController
{
    public readonly IEmpresaRepository _repository;
    public readonly IEmpresaService _service;

    public EmpresaController(
        INotificador notificador,
        IUser appUser,
        IEmpresaRepository repository,
        IEmpresaService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Empresa>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-grupo-economico/{id:guid}")]
    public async Task<IEnumerable<Empresa>> ObterPorGrupoEconomico(Guid id)
    {
        return await _repository.ObterPorGrupoEconomico(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Empresa>> ObterPorId(Guid id)
    {
        var empresa = await _repository.ObterPorId(id);

        if (empresa == null) return NotFound();

        return empresa;
    }

    [HttpPost]
    public async Task<ActionResult<Empresa>> Adicionar(Empresa empresa)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(empresa);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, Empresa empresa)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != empresa.Id)
        {
            NotificarErro("Os ids informados não são iguais");
            return CustomResponse();
        }

        var atualizacao = await _repository.ObterPorId(id);

        if (atualizacao == null) return NotFound();

        atualizacao.Cnpj = empresa.Cnpj;
        atualizacao.RazaoSocial = empresa.RazaoSocial;
        atualizacao.NomeFantasia = empresa.NomeFantasia;
        atualizacao.Cep = empresa.Cep;
        atualizacao.Logradouro = empresa.Logradouro;
        atualizacao.Numero = empresa.Numero;
        atualizacao.Complemento = empresa.Complemento;
        atualizacao.Bairro = empresa.Bairro;
        atualizacao.MunicipioId = empresa.MunicipioId;
        atualizacao.EstadoId = empresa.EstadoId;        

        await _service.Atualizar(atualizacao);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Empresa>> Excluir(Guid id)
    {
        var empresa = await _repository.ObterPorId(id);

        if (empresa == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}

