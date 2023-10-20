using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Models.Cadastros;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColabRH.Data.Repository.Cadastros;

public class GrauParentescoRepository : Repository<GrauParentesco>, IGrauParentescoRepository
{
    public GrauParentescoRepository(ColabRHDbContext db) : base(db) { }

    public async Task<IEnumerable<GrauParentesco>> ObterPorGrupoEconomico(Guid id)
    {
        return await Db.GrausParentesco
            .AsNoTracking()
            .Where(e => e.GrupoEconomicoId == id)
            .ToListAsync();
    }
}
