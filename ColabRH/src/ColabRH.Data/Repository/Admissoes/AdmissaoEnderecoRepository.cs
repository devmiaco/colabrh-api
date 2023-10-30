using ColabRH.Business.Interfaces.Admissoes;
using ColabRH.Business.Models.Admissoes;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ColabRH.Data.Repository.Admissoes;

public class AdmissaoEnderecoRepository : Repository<AdmissaoEndereco>, IAdmissaoEnderecoRepository
{
    public AdmissaoEnderecoRepository(ColabRHDbContext db) : base(db) { }

    public async Task<AdmissaoEndereco> ObterPorAdmissao(Guid id)
    {
        return await Db.AdmissoesEndereco
            .AsNoTracking()
            .Where(e => e.AdmissaoId == id)
            .FirstOrDefaultAsync();
    }
}
