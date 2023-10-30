using ColabRH.Business.Interfaces.Admissoes;
using ColabRH.Business.Models.Admissoes;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColabRH.Data.Repository.Admissoes;

public class AdmissaoFormacaoAcademicaRepository : Repository<AdmissaoFormacaoAcademica>, IAdmissaoFormacaoAcademicaRepository
{
    public AdmissaoFormacaoAcademicaRepository(ColabRHDbContext db) : base(db) { }

    public async Task<IEnumerable<AdmissaoFormacaoAcademica>> ObterPorAdmissao(Guid id)
    {
        return await Db.AdmissoesFormacoesAcademica
            .AsNoTracking()
            .Where(e => e.AdmissaoId == id)
            .ToListAsync();
    }
}
