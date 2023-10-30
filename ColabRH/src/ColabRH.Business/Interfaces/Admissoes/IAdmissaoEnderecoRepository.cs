using ColabRH.Business.Models.Admissoes;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Admissoes;

public interface IAdmissaoEnderecoRepository : IRepository<AdmissaoEndereco>
{
    Task<AdmissaoEndereco> ObterPorAdmissao(Guid id);
}
