using ColabRH.Business.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColabRH.Business.Models.Admissoes;

public class AdmissaoDependente : Entity
{
    public Guid AdmissaoId { get; set; }

    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public TipoSexo TipoSexo { get; set; }
    public TipoGenero TipoGenero { get; set; }
    public TipoCorRaca TipoCorRaca { get; set; }
    public TipoEstadoCivil TipoEstadoCivil { get; set; }
    public DateTime? DataCasamento { get; set; }
    public string NomeMae { get; set; }
    public string NomePai { get; set; }
    public decimal Peso { get; set; }
    public decimal Altura { get; set; }
    public string Cpf { get; set; }
    public string Rg { get; set; }
    public string Cns { get; set; }
    public string NumeroNascidoVivo { get; set; }
    public bool Universitario { get; set; }
    public bool Pcd { get; set; }
    public bool DependenteIR { get; set; }

    public Admissao Admissao { get; set; }
}
