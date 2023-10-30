using ColabRH.Business.Models.Admissoes;
using System;
using System.Threading.Tasks;

namespace ColabRH.Business.Interfaces.Admissoes;

public interface IAdmissaoDadosBancariosService : IDisposable
{
    Task Adicionar(AdmissaoDadosBancarios admissaoDadosBancarios);
    Task Atualizar(AdmissaoDadosBancarios admissaoDadosBancarios);
    Task Remover(Guid id);
}
