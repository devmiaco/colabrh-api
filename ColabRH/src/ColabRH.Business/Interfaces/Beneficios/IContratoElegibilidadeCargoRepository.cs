using ColabRH.Business.Models.Beneficios;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace ColabRH.Business.Interfaces.Beneficios;

public interface IContratoElegibilidadeCargoRepository : IRepository<ContratoElegibilidadeCargo>
{
    Task<IEnumerable<ContratoElegibilidadeCargo>> ObterPorContratoElegibilidade(Guid id);
}
