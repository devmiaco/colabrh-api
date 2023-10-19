using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Models.Cadastros;
using ColabRH.Business.Validations.Cadastros;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Cadastros;

public class GradeService : BaseService, IGradeService
{
    private readonly IGradeRepository _repository;

    public GradeService(
        INotificador notificador,
        IGradeRepository repository) : base(notificador)
    {
        _repository = repository;
    }

    public async Task Adicionar(Grade grade)
    {
        if (!ExecutarValidacao(new GradeValidation(), grade)) return;

        await _repository.Adicionar(grade);
    }

    public async Task Atualizar(Grade grade)
    {
        if (!ExecutarValidacao(new GradeValidation(), grade)) return;

        await _repository.Atualizar(grade);
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
