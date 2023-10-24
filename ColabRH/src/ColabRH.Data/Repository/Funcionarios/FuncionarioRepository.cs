using ColabRH.Business.Interfaces.Funcionarios;
using ColabRH.Business.Models.Funcionarios;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColabRH.Data.Repository.Funcionarios;

public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
{
    public FuncionarioRepository(ColabRHDbContext db) : base(db) { }

    public async Task<IEnumerable<Funcionario>> ObterPorGrupoEconomico(Guid id)
    {
        return await Db.Funcionarios
            .AsNoTracking()
            .Where(e => e.GrupoEconomicoId == id)
            .ToListAsync();
    }
}
