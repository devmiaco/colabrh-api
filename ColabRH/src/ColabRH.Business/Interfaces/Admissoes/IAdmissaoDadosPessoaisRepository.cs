using ColabRH.Business.Models.Admissoes;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Admissoes;

public interface IAdmissaoDadosPessoaisRepository : IRepository<AdmissaoDadosPessoais>
{
    Task<AdmissaoDadosPessoais> ObterPorAdmissao(Guid id);
}
