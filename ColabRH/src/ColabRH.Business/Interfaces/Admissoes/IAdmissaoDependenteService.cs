using ColabRH.Business.Models.Admissoes;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Admissoes;

public interface IAdmissaoDependenteService : IDisposable
{
    Task Adicionar(AdmissaoDependente admissaoDependente);
    Task Atualizar(AdmissaoDependente admissaoDependente);
    Task Remover(Guid id);
}
