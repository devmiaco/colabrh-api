using ColabRH.Business.Models.Admissoes;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Admissoes;

public interface IAdmissaoDadosPessoaisService : IDisposable
{
    Task Adicionar(AdmissaoDadosPessoais admissaoDadosPessoais);
    Task Atualizar(AdmissaoDadosPessoais admissaoDadosPessoais);
    Task Remover(Guid id);
}
