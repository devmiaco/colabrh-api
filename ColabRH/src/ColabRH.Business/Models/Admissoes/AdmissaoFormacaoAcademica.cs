using ColabRH.Business.Models.Enums;
using System;

namespace ColabRH.Business.Models.Admissoes;

public class AdmissaoFormacaoAcademica : Entity
{
    public Guid AdmissaoId { get; set; }

    public TipoEscolaridade TipoEscolaridade { get; set; }
    public string InstituicaoEnsino { get; set; }
    public string Curso { get; set; }
    public int AnoConclusao { get; set; }
    public string Certificado { get; set; }

    public Admissao Admissao { get; set; }
}
