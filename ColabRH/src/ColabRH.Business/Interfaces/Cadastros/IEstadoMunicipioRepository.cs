using ColabRH.Business.Models.Cadastros;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Cadastros;

public interface IEstadoMunicipioRepository : IRepository<Estado>
{
    Task<IEnumerable<Estado>> ObterEstado();
    Task<Estado> ObterEstadoPorIBGE(string ibge);
    Task<IEnumerable<Municipio>> ObterMunicipioPorEstado(Guid id);
    Task<Municipio> ObterMunicipioPorIBGE(string ibge);
}
