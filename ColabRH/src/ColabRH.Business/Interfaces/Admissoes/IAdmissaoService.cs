using ColabRH.Business.Models.Admissoes;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Admissoes;

public interface IAdmissaoService : IDisposable
{
    Task Adicionar(Admissao admissao);
    Task Atualizar(Admissao admissao);
    Task Remover(Guid id);
}
