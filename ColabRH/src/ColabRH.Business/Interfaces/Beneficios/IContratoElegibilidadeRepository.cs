using ColabRH.Business.Models.Beneficios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Beneficios;

public interface IContratoElegibilidadeRepository : IRepository<ContratoElegibilidade>
{
    Task<IEnumerable<ContratoElegibilidade>> ObterPorContrato(Guid id);
}
