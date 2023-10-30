using ColabRH.Business.Models.Admissoes;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Admissoes;

public interface IAdmissaoDocumentoService : IDisposable
{
    Task Adicionar(AdmissaoDocumento admissaoDocumento);
    Task Atualizar(AdmissaoDocumento admissaoDocumento);
    Task Remover(Guid id);
}
