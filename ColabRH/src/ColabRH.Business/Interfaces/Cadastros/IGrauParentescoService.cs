using ColabRH.Business.Models.Cadastros;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Cadastros;

public interface IGrauParentescoService : IDisposable
{
    Task Adicionar(GrauParentesco grauParentesco);
    Task Atualizar(GrauParentesco grauParentesco);
    Task Remover(Guid id);
}
