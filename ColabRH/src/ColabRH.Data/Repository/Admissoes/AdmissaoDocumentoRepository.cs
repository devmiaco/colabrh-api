using ColabRH.Business.Interfaces.Admissoes;
using ColabRH.Business.Models.Admissoes;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ColabRH.Data.Repository.Admissoes;

public class AdmissaoDocumentoRepository : Repository<AdmissaoDocumento>, IAdmissaoDocumentoRepository
{
    public AdmissaoDocumentoRepository(ColabRHDbContext db) : base(db) { }

    public async Task<AdmissaoDocumento> ObterPorAdmissao(Guid id)
    {
        return await Db.AdmissoesDocumentos
            .AsNoTracking()
            .Where(e => e.AdmissaoId == id)
            .FirstOrDefaultAsync();
    }
}
