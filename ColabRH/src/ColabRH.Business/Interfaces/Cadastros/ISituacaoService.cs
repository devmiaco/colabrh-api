using ColabRH.Business.Models.Cadastros;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Cadastros;

public interface ISituacaoService : IDisposable
{
    Task Adicionar(Situacao situacao);
    Task Atualizar(Situacao situacao);
    Task Remover(Guid id);
}
