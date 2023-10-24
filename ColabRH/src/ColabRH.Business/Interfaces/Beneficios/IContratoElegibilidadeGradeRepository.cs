using ColabRH.Business.Models.Beneficios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Beneficios;

public interface IContratoElegibilidadeGradeRepository : IRepository<ContratoElegibilidadeGrade>
{
    Task<IEnumerable<ContratoElegibilidadeGrade>> ObterPorContratoElegibilidade(Guid id);
}
