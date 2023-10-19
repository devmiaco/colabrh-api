using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Models.Cadastros;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColabRH.Data.Repository;

public class VinculoRepository : Repository<Vinculo>, IVinculoRepository
{
    public VinculoRepository(ColabRHDbContext db) : base(db) { }

    public async Task<IEnumerable<Vinculo>> ObterPorGrupoEconomico(Guid id)
    {
        return await Db.Vinculos
            .AsNoTracking()
            .Where(e => e.GrupoEconomicoId == id)
            .ToListAsync();
    }
}
