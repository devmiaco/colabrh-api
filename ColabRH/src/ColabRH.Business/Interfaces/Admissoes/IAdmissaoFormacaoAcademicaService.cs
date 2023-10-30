using ColabRH.Business.Models.Admissoes;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Admissoes;

public interface IAdmissaoFormacaoAcademicaService : IDisposable
{
    Task Adicionar(AdmissaoFormacaoAcademica admissaoFormacaoAcademica);
    Task Atualizar(AdmissaoFormacaoAcademica admissaoFormacaoAcademica);
    Task Remover(Guid id);
}
