using ColabRH.Business.Interfaces.Beneficios;
using ColabRH.Business.Models.Beneficios;
using ColabRH.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColabRH.Data.Repository.Beneficios
{
    public class ContratoGrauParentescoRepository : Repository<ContratoGrauParentesco>, IContratoGrauParentescoRepository
    {
        public ContratoGrauParentescoRepository(ColabRHDbContext db) : base(db) { }

        public async Task<IEnumerable<ContratoGrauParentesco>> ObterPorContrato(Guid id)
        {
            return await Db.ContratosGrauParentesco
            .AsNoTracking()
            .Where(e => e.ContratoBeneficioId == id)
            .ToListAsync();
        }
    }
}
