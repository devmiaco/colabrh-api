using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Beneficios;
using ColabRH.Business.Models.Beneficios;
using ColabRH.Business.Validations.Beneficios;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Beneficios;

public class ContratoElegibilidadeGradeService : BaseService, IContratoElegibilidadeGradeService
{
    private readonly IContratoElegibilidadeGradeRepository _repository;

    public ContratoElegibilidadeGradeService(
        INotificador notificador, 
        IContratoElegibilidadeGradeRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(ContratoElegibilidadeGrade contratoElegibilidadeGrade)
    {
        if (!ExecutarValidacao(new ContratoElegibilidadeGradeValidation(), contratoElegibilidadeGrade)) return;

        await _repository.Adicionar(contratoElegibilidadeGrade);
    }

    public async Task Atualizar(ContratoElegibilidadeGrade contratoElegibilidadeGrade)
    {
        if (!ExecutarValidacao(new ContratoElegibilidadeGradeValidation(), contratoElegibilidadeGrade)) return;

        await _repository.Atualizar(contratoElegibilidadeGrade);
    }        

    public async Task Remover(Guid id)
    {
        await _repository.Remover(id);
    }

    public void Dispose()
    {
        _repository?.Dispose();
    }
}
