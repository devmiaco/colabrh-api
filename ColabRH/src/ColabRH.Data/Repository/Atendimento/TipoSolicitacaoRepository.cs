using ColabRH.Business.Interfaces.Atendimento;
using ColabRH.Business.Models.Atendimento;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColabRH.Data.Repository.Atendimento
{
    public class TipoSolicitacaoRepository : Repository<TipoSolicitacao>, ITipoSolicitacaoRepository
    {
        public TipoSolicitacaoRepository(ColabRHDbContext db) : base(db) { }

        public async Task<IEnumerable<TipoSolicitacao>> ObterPorCategoria(Guid id)
        {
            return await Db.TiposSolicitacao
                .AsNoTracking()
                .Where(e => e.CategoriaTipoSolicitacaoId == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<TipoSolicitacao>> ObterPorGrupoEconomico(Guid id)
        {
            return await Db.TiposSolicitacao
                .AsNoTracking()
                .Where(e => e.GrupoEconomicoId == id)
                .ToListAsync();
        }
    }
}
