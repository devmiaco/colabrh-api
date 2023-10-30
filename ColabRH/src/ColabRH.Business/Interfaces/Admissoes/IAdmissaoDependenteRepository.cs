using ColabRH.Business.Models.Admissoes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Admissoes;

public interface IAdmissaoDependenteRepository : IRepository<AdmissaoDependente>
{
    Task<IEnumerable<AdmissaoDependente>> ObterPorAdmissao(Guid id);
}
