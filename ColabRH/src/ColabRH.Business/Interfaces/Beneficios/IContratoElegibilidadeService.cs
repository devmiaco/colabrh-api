using ColabRH.Business.Models.Beneficios;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Beneficios;

public interface IContratoElegibilidadeService : IDisposable
{
    Task Adicionar(ContratoElegibilidade contratoElegibilidade);
    Task Atualizar(ContratoElegibilidade contratoElegibilidade);
    Task Remover(Guid id);
}
