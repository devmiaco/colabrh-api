using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Models.Cadastros;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColabRH.Data.Repository.Cadastros;

public class CargoRepository : Repository<Cargo>, ICargoRepository
{
    public CargoRepository(ColabRHDbContext db) : base(db) { }

    public async Task<IEnumerable<Cargo>> ObterPorGrade(Guid id)
    {
        return await Db.Cargos
            .AsNoTracking()
            .Where(e => e.GradeId == id)
            .ToListAsync();
    }

    public async Task<IEnumerable<Cargo>> ObterPorGrupoEconomico(Guid id)
    {
        return await Db.Cargos
            .AsNoTracking()
            .Where(e => e.GrupoEconomicoId == id)
            .ToListAsync();
    }
}
