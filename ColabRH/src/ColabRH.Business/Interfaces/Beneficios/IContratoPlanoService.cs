using ColabRH.Business.Models.Beneficios;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Beneficios;

public interface IContratoPlanoService : IDisposable
{
    Task Adicionar(ContratoPlano contratoPlano);
    Task Atualizar(ContratoPlano contratoPlano);
    Task Remover(Guid id);
}
