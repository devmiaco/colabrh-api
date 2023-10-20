using ColabRH.Business.Models.Beneficios;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Beneficios;

public interface IContratoBeneficioService : IDisposable
{
    Task Adicionar(ContratoBeneficio contratoBeneficio);
    Task Atualizar(ContratoBeneficio contratoBeneficio);
    Task Remover(Guid id);
}
