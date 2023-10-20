using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Models.Cadastros;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColabRH.Data.Repository.Cadastros;

public class OperadoraRepository : Repository<Operadora>, IOperadoraRepository
{
    public OperadoraRepository(ColabRHDbContext db) : base(db) { }

    public async Task<IEnumerable<Operadora>> ObterPorGrupoEconomico(Guid id)
    {
        return await Db.Operadoras
            .AsNoTracking()
            .Where(e => e.GrupoEconomicoId == id)
            .ToListAsync();
    }
}
