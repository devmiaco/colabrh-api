using ColabRH.Business.Interfaces.Admissoes;
using ColabRH.Business.Models.Admissoes;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ColabRH.Data.Repository.Admissoes;

public class AdmissaoDadosBancariosRepository : Repository<AdmissaoDadosBancarios>, IAdmissaoDadosBancariosRepository
{
    public AdmissaoDadosBancariosRepository(ColabRHDbContext db) : base(db) { }

    public async Task<AdmissaoDadosBancarios> ObterPorAdmissao(Guid id)
    {
        return await Db.AdmissoesDadosBancarios
            .AsNoTracking()
            .Where(e => e.AdmissaoId == id)
            .FirstOrDefaultAsync();
    }
}
