using ColabRH.Business.Models.Cadastros;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Cadastros;

public interface IGradeService : IDisposable
{
    Task Adicionar(Grade grade);
    Task Atualizar(Grade grade);
    Task Remover(Guid id);
}
