using ColabRH.Business.Models.Beneficios;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Beneficios;

public interface IContratoSubestipulanteService : IDisposable
{
    Task Adicionar(ContratoSubestipulante contratoSubestipulante);
    Task Atualizar(ContratoSubestipulante contratoSubestipulante);
    Task Remover(Guid id);
}
