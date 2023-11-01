using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Atendimento;
using ColabRH.Business.Models.Atendimento;
using ColabRH.Business.Validations.Atendimento;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Services.Atendimento
{
    public class CategoriaTipoSolicitacaoService : BaseService, ICategoriaTipoSolicitacaoService
    {
        private readonly ICategoriaTipoSolicitacaoRepository _repository;

        public CategoriaTipoSolicitacaoService(
            INotificador notificador, 
            ICategoriaTipoSolicitacaoRepository repository) : base(notificador)
        {
            _repository = repository;
        }

        public async Task Adicionar(CategoriaTipoSolicitacao categoriaTipoSolicitacao)
        {
            if (!ExecutarValidacao(new CategoriaTipoSolicitacaoValidation(), categoriaTipoSolicitacao)) return;

            await _repository.Adicionar(categoriaTipoSolicitacao);
        }

        public async Task Atualizar(CategoriaTipoSolicitacao categoriaTipoSolicitacao)
        {
            if (!ExecutarValidacao(new CategoriaTipoSolicitacaoValidation(), categoriaTipoSolicitacao)) return;

            await _repository.Atualizar(categoriaTipoSolicitacao);
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
}
