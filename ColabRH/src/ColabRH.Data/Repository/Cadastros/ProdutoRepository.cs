using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Models.Cadastros;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColabRH.Data.Repository.Cadastros;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    public ProdutoRepository(ColabRHDbContext db) : base(db) { }

    public async Task<IEnumerable<Produto>> ObterPorOperadora(Guid id)
    {
        return await Db.Produtos
            .AsNoTracking()
            .Where(e => e.OperadoraId == id)
            .ToListAsync();
    }
}
