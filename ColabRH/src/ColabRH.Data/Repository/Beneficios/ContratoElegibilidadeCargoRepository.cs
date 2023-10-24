using ColabRH.Business.Interfaces.Beneficios;
using ColabRH.Business.Models.Beneficios;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColabRH.Data.Repository.Beneficios;

public class ContratoElegibilidadeCargoRepository : Repository<ContratoElegibilidadeCargo>, IContratoElegibilidadeCargoRepository
{
    public ContratoElegibilidadeCargoRepository(ColabRHDbContext db) : base(db) { }

    public async Task<IEnumerable<ContratoElegibilidadeCargo>> ObterPorContratoElegibilidade(Guid id)
    {
        return await Db.ContratosElegibilidadeCargo
            .AsNoTracking()
            .Where(e => e.ContratoElegibilidadeId == id)
            .ToListAsync();
    }
}
