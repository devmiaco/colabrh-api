using ColabRH.Business.Models.Beneficios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Beneficios;

public interface IContratoGrauParentescoRepository : IRepository<ContratoGrauParentesco>
{
    Task<IEnumerable<ContratoGrauParentesco>> ObterPorContrato(Guid id);
}
