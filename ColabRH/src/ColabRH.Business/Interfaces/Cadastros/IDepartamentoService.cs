using ColabRH.Business.Models.Cadastros;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Cadastros;

public interface IDepartamentoService : IDisposable
{
    Task Adicionar(Departamento departamento);
    Task Atualizar(Departamento departamento);
    Task Remover(Guid id);
}
