using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Models.Cadastros;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Api.Controllers.Cadastros;

[Authorize]
[Route("api/estado-municipio")]
public class EstadoMunicipioController : MainController
{
    public readonly IEstadoMunicipioRepository _repository;

    public EstadoMunicipioController(
        INotificador notificador,
        IUser appUser,
        IEstadoMunicipioRepository repository) : base(notificador, appUser)
    {
        _repository = repository;
    }

    [HttpGet("estado")]
    public async Task<IEnumerable<Estado>> ObterTodosEstados()
    {
        return await _repository.ObterEstado();
    }

    [HttpGet("estado-ibge/{codigo}")]
    public async Task<Estado> ObterEstadoPorIBGE(string codigo)
    {
        return await _repository.ObterEstadoPorIBGE(codigo);
    }

    [HttpGet("municipio-por-estado/{id:guid}")]
    public async Task<IEnumerable<Municipio>> ObterMunicipioPorEstado(Guid id)
    {
        return await _repository.ObterMunicipioPorEstado(id);
    }

    [HttpGet("municipio-ibge/{codigo}")]
    public async Task<Municipio> ObterMunicipioPorIBGE(string codigo)
    {
        return await _repository.ObterMunicipioPorIBGE(codigo);
    }
}
