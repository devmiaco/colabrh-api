using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Models.Cadastros;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColabRH.Data.Repository.Cadastros;

public class PlanoRepository : Repository<Plano>, IPlanoRepository
{
    public PlanoRepository(ColabRHDbContext db) : base(db) { }

    public async Task<IEnumerable<Plano>> ObterPorProduto(Guid id)
    {
        return await Db.Planos
            .AsNoTracking()
            .Where(e => e.ProdutoId == id)
            .ToListAsync();
    }
}
