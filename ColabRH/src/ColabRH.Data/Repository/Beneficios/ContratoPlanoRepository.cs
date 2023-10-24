using ColabRH.Business.Interfaces.Beneficios;
using ColabRH.Business.Models.Beneficios;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColabRH.Data.Repository.Beneficios;

public class ContratoPlanoRepository : Repository<ContratoPlano>, IContratoPlanoRepository
{
    public ContratoPlanoRepository(ColabRHDbContext db) : base(db) { }

    public async Task<IEnumerable<ContratoPlano>> ObterPorContrato(Guid id)
    {
        return await Db.ContratosPlano
            .AsNoTracking()
            .Where(e => e.ContratoBeneficioId == id)
            .ToListAsync();
    }
}
