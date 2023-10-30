using ColabRH.Business.Interfaces.Admissoes;
using ColabRH.Business.Models.Admissoes;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ColabRH.Data.Repository.Admissoes;

public class AdmissaoDadosPessoaisRepository : Repository<AdmissaoDadosPessoais>, IAdmissaoDadosPessoaisRepository
{
    public AdmissaoDadosPessoaisRepository(ColabRHDbContext db) : base(db) { }

    public async Task<AdmissaoDadosPessoais> ObterPorAdmissao(Guid id)
    {
        return await Db.AdmissoesDadosPessoais
            .AsNoTracking()
            .Where(e => e.AdmissaoId == id)
            .FirstOrDefaultAsync();
    }
}
