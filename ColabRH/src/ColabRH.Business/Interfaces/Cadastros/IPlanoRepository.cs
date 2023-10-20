using ColabRH.Business.Models.Cadastros;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Cadastros;

public interface IPlanoRepository : IRepository<Plano>
{
    Task<IEnumerable<Plano>> ObterPorProduto(Guid id);
}
