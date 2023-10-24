using ColabRH.Business.Models.Beneficios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Beneficios;

public interface IContratoSubestipulanteRepository : IRepository<ContratoSubestipulante>
{
    Task<IEnumerable<ContratoSubestipulante>> ObterPorContrato(Guid id);
}
