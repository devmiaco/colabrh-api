using ColabRH.Business.Interfaces.Beneficios;
using ColabRH.Business.Models.Beneficios;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColabRH.Data.Repository.Beneficios;

public class ContratoBeneficioRepository : Repository<ContratoBeneficio>, IContratoBeneficioRepository
{
    public ContratoBeneficioRepository(ColabRHDbContext db) : base(db) { }

    public async Task<IEnumerable<ContratoBeneficio>> ObterPorGrupoEconomico(Guid id)
    {
        return await Db.ContratosBeneficio
            .AsNoTracking()
            .Where(e => e.GrupoEconomicoId == id)
            .ToListAsync();
    }
}
