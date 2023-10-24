using ColabRH.Business.Models.Beneficios;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Beneficios;

public interface IContratoElegibilidadeCargoService : IDisposable
{
    Task Adicionar(ContratoElegibilidadeCargo contratoElegibilidadeCargo);
    Task Atualizar(ContratoElegibilidadeCargo contratoElegibilidadeCargo);
    Task Remover(Guid id);
}
