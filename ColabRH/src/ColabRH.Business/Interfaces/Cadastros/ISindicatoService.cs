using ColabRH.Business.Models.Cadastros;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Cadastros;

public interface ISindicatoService : IDisposable
{
    Task Adicionar(Sindicato sindicato);
    Task Atualizar(Sindicato sindicato);
    Task Remover(Guid id);
}
