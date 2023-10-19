using ColabRH.Business.Models.Cadastros;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Cadastros;

public interface ICargoService : IDisposable
{
    Task Adicionar(Cargo cargo);
    Task Atualizar(Cargo cargo);
    Task Remover(Guid id);
}
