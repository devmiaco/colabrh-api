using ColabRH.Business.Models.Cadastros;
using ColabRH.Business.Models.Enums;
using ColabRH.Business.Models.Funcionarios;
using System;

namespace ColabRH.Business.Models.Atendimento;

public class Solicitacao : Entity
{
    public Guid GrupoEconomicoId { get; set; }
    public Guid TipoSolicitacaoId { get; set; }
    public Guid FuncionarioId { get; set; }
    public DateTime DataAbertura { get; set; }
    public DateTime? DataFechamento { get; set; }
    public TipoStatusSolicitacao TipoStatus { get; set; }
    public string Assunto { get; set; }
    public string Descricao { get; set; }
    public string Anexo { get; set; }
    public Guid UsuarioResponsavel { get; set; }

    public GrupoEconomico GrupoEconomico { get; set; }
    public TipoSolicitacao TipoSolicitacao { get; set; }
    public Funcionario Funcionario { get; set; }
}
