using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Models.Cadastros;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColabRH.Data.Repository;

public class GrupoEconomicoRepository : Repository<GrupoEconomico>, IGrupoEconomicoRepository
{
    public GrupoEconomicoRepository(ColabRHDbContext db) : base(db) { }

    public async Task<IEnumerable<GrupoEconomico>> ObterAtivos()
    {
        return await Db.GruposEconomicos
            .AsNoTracking()
            .Where(g => g.Ativo)
            .ToListAsync();
    }
}
