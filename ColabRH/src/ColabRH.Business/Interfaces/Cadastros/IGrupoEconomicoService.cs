using ColabRH.Business.Models.Cadastros;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Cadastros;

public interface IGrupoEconomicoService : IDisposable
{
    Task Adicionar(GrupoEconomico grupoEconomico);
    Task Atualizar(GrupoEconomico grupoEconomico);
    Task Remover(Guid id);
}
