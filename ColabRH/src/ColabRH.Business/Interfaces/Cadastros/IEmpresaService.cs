using ColabRH.Business.Models.Cadastros;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Cadastros;

public interface IEmpresaService : IDisposable
{
    Task Adicionar(Empresa empresa);
    Task Atualizar(Empresa empresa);
    Task Remover(Guid id);
}
