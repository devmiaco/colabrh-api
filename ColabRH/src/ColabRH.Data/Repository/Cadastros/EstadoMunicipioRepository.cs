using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Models.Cadastros;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColabRH.Data.Repository.Cadastros;

public class EstadoMunicipioRepository : Repository<Estado>, IEstadoMunicipioRepository
{
    public EstadoMunicipioRepository(ColabRHDbContext db) : base(db) { }

    public async Task<IEnumerable<Estado>> ObterEstado()
    {
        return await Db.Estados
            .AsNoTracking()
            .OrderBy(e => e.Nome)
            .ToListAsync();
    }

    public async Task<Estado> ObterEstadoPorIBGE(string ibge)
    {
        return await Db.Estados
            .AsNoTracking()
            .Where(e => e.CodigoIBGE == ibge)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Municipio>> ObterMunicipioPorEstado(Guid id)
    {
        return await Db.Municipios
            .AsNoTracking()
            .Where(c => c.EstadoId == id)
            .OrderBy(c => c.Nome)
            .ToListAsync();
    }

    public async Task<Municipio> ObterMunicipioPorIBGE(string ibge)
    {
        return await Db.Municipios
            .AsNoTracking()
            .Where(e => e.CodigoIBGE == ibge)
            .FirstOrDefaultAsync();
    }
}
