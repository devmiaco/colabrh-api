using ColabRH.Business.Models.Cadastros;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Cadastros;

public interface IPlanoService : IDisposable
{
    Task Adicionar(Plano plano);
    Task Atualizar(Plano plano);
    Task Remover(Guid id);
}
