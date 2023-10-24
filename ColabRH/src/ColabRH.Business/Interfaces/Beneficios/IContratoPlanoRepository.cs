using ColabRH.Business.Models.Beneficios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Beneficios;

public interface IContratoPlanoRepository : IRepository<ContratoPlano>
{
    Task<IEnumerable<ContratoPlano>> ObterPorContrato(Guid id);
}
