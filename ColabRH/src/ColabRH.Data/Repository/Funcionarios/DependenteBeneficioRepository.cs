using ColabRH.Business.Interfaces.Funcionarios;
using ColabRH.Business.Models.Funcionarios;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColabRH.Data.Repository.Funcionarios;

public class DependenteBeneficioRepository : Repository<DependenteBeneficio>, IDependenteBeneficioRepository
{
    public DependenteBeneficioRepository(ColabRHDbContext db) : base(db) { }

    public async Task<IEnumerable<DependenteBeneficio>> ObterPorDependente(Guid id)
    {
        return await Db.DependenteBeneficios
            .AsNoTracking()
            .Where(e => e.DependenteId == id)
            .ToListAsync();
    }
}
