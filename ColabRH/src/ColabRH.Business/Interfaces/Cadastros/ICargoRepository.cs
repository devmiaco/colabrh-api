using ColabRH.Business.Models.Cadastros;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Cadastros;

public interface ICargoRepository : IRepository<Cargo>
{
    Task<IEnumerable<Cargo>> ObterPorGrupoEconomico(Guid id);
    Task<IEnumerable<Cargo>> ObterPorGrade(Guid id);
}
