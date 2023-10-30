using ColabRH.Business.Models.Admissoes;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Admissoes;

public interface IAdmissaoEnderecoService : IDisposable
{
    Task Adicionar(AdmissaoEndereco admissaoEndereco);
    Task Atualizar(AdmissaoEndereco admissaoEndereco);
    Task Remover(Guid id);
}
