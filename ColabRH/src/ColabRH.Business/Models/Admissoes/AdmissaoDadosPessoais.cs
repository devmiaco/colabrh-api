using ColabRH.Business.Models.Enums;
using System;

namespace ColabRH.Business.Models.Admissoes;

public class AdmissaoDadosPessoais : Entity
{
    public Guid AdmissaoId { get; set; }

    public string Nacionalidade { get; set; }
    public string UfNatal { get; set; }
    public string CidadeNatal { get; set; }
    public TipoCorRaca TipoCorRaca { get; set; }
    public TipoGenero TipoGenero { get; set; }
    public string NomeSocial { get; set; }
    public TipoEstadoCivil TipoEstadoCivil { get; set; }
    public DateTime DataNascimento { get; set; }
    public string NomeMae { get; set; }
    public string NomePai { get; set; }
    public bool PossuiDeficiencia { get; set; }
    public TipoDeficiencia TipoDeficiencia { get; set; }
    public string ObservacaoDeficiencia { get; set; }
    public TipoStatusPassoAdmissao TipoStatus { get; set; }

    public Admissao Admissao { get; set; }
}
