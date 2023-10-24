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
[Route("api/funcionario")]
public class FuncionarioController : MainController
{
    public readonly IFuncionarioRepository _repository;
    public readonly IFuncionarioService _service;

    public FuncionarioController(
        INotificador notificador,
        IUser appUser,
        IFuncionarioRepository repository,
        IFuncionarioService service) : base(notificador, appUser)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Funcionario>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    [HttpGet("por-grupo-economico/{id:guid}")]
    public async Task<IEnumerable<Funcionario>> ObterPorGrupoEconomico(Guid id)
    {
        return await _repository.ObterPorGrupoEconomico(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Funcionario>> ObterPorId(Guid id)
    {
        var cargo = await _repository.ObterPorId(id);

        if (cargo == null) return NotFound();

        return cargo;
    }

    [HttpPost]
    public async Task<ActionResult<Funcionario>> Adicionar(Funcionario funcionario)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Adicionar(funcionario);

        return CustomResponse();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, Funcionario funcionario)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != funcionario.Id)
        {
            NotificarErro("Os ids informados não são iguais");
            return CustomResponse();
        }

        var atualizacao = await _repository.ObterPorId(id);

        if (atualizacao == null) return NotFound();

        atualizacao.EmpresaId = funcionario.EmpresaId;
        atualizacao.GradeId = funcionario.GradeId;
        atualizacao.CargoId = funcionario.CargoId;
        atualizacao.DepartamentoId = funcionario.DepartamentoId;
        atualizacao.SindicatoId = funcionario.SindicatoId;
        atualizacao.VinculoId = funcionario.VinculoId;
        atualizacao.SituacaoId = funcionario.SituacaoId;
        atualizacao.Matricula = funcionario.Matricula;
        atualizacao.DataAdmissao = funcionario.DataAdmissao;
        atualizacao.Nome = funcionario.Nome;
        atualizacao.DataNascimento = funcionario.DataNascimento;
        atualizacao.TipoSexo = funcionario.TipoSexo;
        atualizacao.TipoEstadoCivil = funcionario.TipoEstadoCivil;
        atualizacao.DataCasamento = funcionario.DataCasamento;
        atualizacao.NomeMae = funcionario.NomeMae;
        atualizacao.NomePai = funcionario.NomePai;
        atualizacao.Peso = funcionario.Peso;
        atualizacao.Altura = funcionario.Altura;
        atualizacao.Cpf = funcionario.Cpf;
        atualizacao.Rg = funcionario.Rg;
        atualizacao.TelefoneFixo = funcionario.TelefoneFixo;
        atualizacao.TelefoneCelular = funcionario.TelefoneCelular;
        atualizacao.EmailPessoal = funcionario.EmailPessoal;
        atualizacao.EmailCorporativo = funcionario.EmailCorporativo;
        atualizacao.Cep = funcionario.Cep;
        atualizacao.Logradouro = funcionario.Logradouro;
        atualizacao.Numero = funcionario.Numero;
        atualizacao.Complemento = funcionario.Complemento;
        atualizacao.Bairro = funcionario.Bairro;
        atualizacao.Municipio = funcionario.Municipio;
        atualizacao.Uf = funcionario.Uf;

        await _service.Atualizar(atualizacao);

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Funcionario>> Excluir(Guid id)
    {
        var funcionario = await _repository.ObterPorId(id);

        if (funcionario == null) return NotFound();

        await _service.Remover(id);

        return CustomResponse();
    }
}
