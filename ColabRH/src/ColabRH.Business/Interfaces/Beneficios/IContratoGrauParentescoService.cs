using ColabRH.Business.Models.Beneficios;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Beneficios;

public interface IContratoGrauParentescoService : IDisposable
{
    Task Adicionar(ContratoGrauParentesco contratoGrauParentesco);
    Task Atualizar(ContratoGrauParentesco contratoGrauParentesco);
    Task Remover(Guid id);
}
