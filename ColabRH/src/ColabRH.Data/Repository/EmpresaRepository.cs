using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Models.Cadastros;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColabRH.Data.Repository;

public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
{
    public EmpresaRepository(ColabRHDbContext db) : base(db) { }

    public async Task<IEnumerable<Empresa>> ObterPorGrupoEconomico(Guid id)
    {
        return await Db.Empresas
            .AsNoTracking()
            .Include(e => e.GrupoEconomico)
            .Where(e => e.GrupoEconomicoId == id)
            .ToListAsync();
    }
}
