using ColabRH.Business.Interfaces.Atendimento;
using ColabRH.Business.Models.Atendimento;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColabRH.Data.Repository.Atendimento;

public class SolicitacaoRepository : Repository<Solicitacao>, ISolicitacaoRepository
{
    public SolicitacaoRepository(ColabRHDbContext db) : base(db) { }

    public async Task<IEnumerable<Solicitacao>> ObterPorFuncionario(Guid id)
    {
        return await Db.Solicitacoes
            .AsNoTracking()
            .Where(e => e.FuncionarioId == id)
            .ToListAsync();
    }

    public async Task<IEnumerable<Solicitacao>> ObterPorTipo(Guid id)
    {
        return await Db.Solicitacoes
            .AsNoTracking()
            .Where(e => e.TipoSolicitacaoId == id)
            .ToListAsync();
    }
}
