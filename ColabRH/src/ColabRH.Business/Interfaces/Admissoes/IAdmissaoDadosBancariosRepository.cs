using ColabRH.Business.Models.Admissoes;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Admissoes;

public interface IAdmissaoDadosBancariosRepository : IRepository<AdmissaoDadosBancarios>
{
    Task<AdmissaoDadosBancarios> ObterPorAdmissao(Guid id);
}
