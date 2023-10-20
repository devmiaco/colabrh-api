using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Models.Cadastros;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColabRH.Data.Repository.Cadastros;

public class SituacaoRepository : Repository<Situacao>, ISituacaoRepository
{
    public SituacaoRepository(ColabRHDbContext db) : base(db) { }

    public async Task<IEnumerable<Situacao>> ObterPorGrupoEconomico(Guid id)
    {
        return await Db.Situacoes
            .AsNoTracking()
            .Where(e => e.GrupoEconomicoId == id)
            .ToListAsync();
    }
}
