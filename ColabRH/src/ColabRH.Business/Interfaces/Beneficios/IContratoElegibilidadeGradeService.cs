using ColabRH.Business.Models.Beneficios;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Beneficios;

public interface IContratoElegibilidadeGradeService : IDisposable
{
    Task Adicionar(ContratoElegibilidadeGrade contratoElegibilidadeGrade);
    Task Atualizar(ContratoElegibilidadeGrade contratoElegibilidadeGrade);
    Task Remover(Guid id);
}
