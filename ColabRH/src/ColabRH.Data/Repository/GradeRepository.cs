using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Models.Cadastros;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColabRH.Data.Repository;

public class GradeRepository : Repository<Grade>, IGradeRepository
{
    public GradeRepository(ColabRHDbContext db) : base(db) { }

    public async Task<IEnumerable<Grade>> ObterPorGrupoEconomico(Guid id)
    {
        return await Db.Grades
            .AsNoTracking()
            .Where(e => e.GrupoEconomicoId == id)
            .ToListAsync();
    }
}
