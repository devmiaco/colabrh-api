using ColabRH.Business.Interfaces.Atendimento;
using ColabRH.Business.Models.Atendimento;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColabRH.Data.Repository.Atendimento;

public class CategoriaTipoSolicitacaoRepository : Repository<CategoriaTipoSolicitacao>, ICategoriaTipoSolicitacaoRepository
{
    public CategoriaTipoSolicitacaoRepository(ColabRHDbContext db) : base(db) { }

    public async Task<IEnumerable<CategoriaTipoSolicitacao>> ObterPorGrupoEconomico(Guid id)
    {
        return await Db.CategoriasTipoSolicitacao
            .AsNoTracking()
            .Where(e => e.GrupoEconomicoId == id)
            .ToListAsync();
    }
}
