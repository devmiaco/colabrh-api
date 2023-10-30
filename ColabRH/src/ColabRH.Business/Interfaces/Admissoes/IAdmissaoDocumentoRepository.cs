using ColabRH.Business.Models.Admissoes;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Admissoes;

public interface IAdmissaoDocumentoRepository : IRepository<AdmissaoDocumento>
{
    Task<AdmissaoDocumento> ObterPorAdmissao(Guid id);
}
