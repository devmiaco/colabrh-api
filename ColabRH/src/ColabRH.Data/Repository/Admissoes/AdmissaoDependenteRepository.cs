using ColabRH.Business.Interfaces.Admissoes;
using ColabRH.Business.Models.Admissoes;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColabRH.Data.Repository.Admissoes;

public class AdmissaoDependenteRepository : Repository<AdmissaoDependente>, IAdmissaoDependenteRepository
{
    public AdmissaoDependenteRepository(ColabRHDbContext db) : base(db) { }

    public async Task<IEnumerable<AdmissaoDependente>> ObterPorAdmissao(Guid id)
    {
        return await Db.AdmissoesDependentes
            .AsNoTracking()
            .Where(e => e.AdmissaoId == id)
            .ToListAsync();
    }
}
