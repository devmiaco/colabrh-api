using ColabRH.Business.Models.Cadastros;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Cadastros;

public interface IVinculoService : IDisposable
{
    Task Adicionar(Vinculo vinculo);
    Task Atualizar(Vinculo vinculo);
    Task Remover(Guid id);
}
