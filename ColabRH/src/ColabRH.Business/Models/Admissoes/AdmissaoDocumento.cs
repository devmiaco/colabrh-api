using ColabRH.Business.Models.Cadastros;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColabRH.Business.Models.Admissoes;

public class AdmissaoDocumento : Entity
{
    public Guid AdmissaoId { get; set; }

    public string RgNumero { get; set; }
    public DateTime RgDataEmissao { get; set; }
    public string RgOrgaoEmissor { get; set; }
    public Guid RgUFEmissorId { get; set; }
    public string RgFrenteComprovante { get; set; }
    public string RgVersoComprovante { get; set; }

    public string CnhNumero { get; set; }
    public DateTime CnhDataEmissao { get; set; }
    public DateTime CnhDataValidade { get; set; }
    public string CnhCategoria { get; set; }
    public string CnhComprovante { get; set; }

    public string CpfNumero { get; set; }
    public string CpfComprovante { get; set; }

    public string ReservistaNumero { get; set; }
    public string ReservistaRA { get; set; }
    public string ReservistaCategoria { get; set; }
    public string ReservistaComprovante { get; set; }

    public string TituloEleitorNumero { get; set; }
    public string TituloEleitorZonaEleitoral { get; set; }
    public string TituloEleitorSecaoEleitoral { get; set; }
    public Guid TituloEleitorEstadoId { get; set; }
    public Guid TituloEleitorMunicipioId { get; set; }
    public string TituloEleitorComprovante { get; set; }

    public string CarteiraTrabalhoNumero { get; set; }
    public string CarteiraTrabalhoSerie { get; set; }
    public DateTime CarteiraTrabalhoDataEmissao { get; set; }
    public Guid CarteiraTrabalhoEstadoEmissorId { get; set; }
    public string CarteiraTrabalhoPIS { get; set; }
    public string CarteiraTrabalhoPrimeiraFolhaComprovante { get; set; }
    public string CarteiraTrabalhoSegundaFolhaComprovante { get; set; }

    public Admissao Admissao { get; set; }
    public Estado RgUFEmissor { get; set; }
    public Estado TituloEleitorEstado { get; set; }
    public Municipio TituloEleitorMunicipio { get; set; }
    public Estado CarteiraTrabalhoEstadoEmissor { get; set; }
}
