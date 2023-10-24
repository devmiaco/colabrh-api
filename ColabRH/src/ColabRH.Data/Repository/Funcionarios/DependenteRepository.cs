using ColabRH.Business.Interfaces.Funcionarios;
using ColabRH.Business.Models.Funcionarios;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColabRH.Data.Repository.Funcionarios;

public class DependenteRepository : Repository<Dependente>, IDependenteRepository
{
    public DependenteRepository(ColabRHDbContext db) : base(db) { }

    public async Task<IEnumerable<Dependente>> ObterPorFuncionario(Guid id)
    {
        return await Db.Dependentes
            .AsNoTracking()
            .Where(e => e.FuncionarioId == id)
            .ToListAsync();
    }
}
