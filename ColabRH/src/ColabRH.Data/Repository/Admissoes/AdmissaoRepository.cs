using ColabRH.Business.Interfaces.Admissoes;
using ColabRH.Business.Models.Admissoes;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColabRH.Data.Repository.Admissoes;

public class AdmissaoRepository : Repository<Admissao>, IAdmissaoRepository
{
    public AdmissaoRepository(ColabRHDbContext db) : base(db) { }

    public async Task<IEnumerable<Admissao>> ObterPorGrupoEconomico(Guid id)
    {
        return await Db.Admissoes
            .AsNoTracking()
            .Where(e => e.GrupoEconomicoId == id)
            .ToListAsync();
    }
}
