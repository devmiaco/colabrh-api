using ColabRH.Business.Models.Cadastros;
using ColabRH.Business.Models.Enums;
using System;

namespace ColabRH.Business.Models.Admissoes;

public class AdmissaoDadosBancarios : Entity
{
    public Guid AdmissaoId { get; set; }

    public TipoContaBancaria TipoContaBancaria { get; set; }
    public TipoModalidadeContaBancaria TipoModalidadeConta { get; set; }
    public Guid BancoId { get; set; }
    public string Agencia { get; set; }
    public string Conta { get; set; }
    public string DigitoConta { get; set; }
    public string ChavePix { get; set; }

    public Admissao Admissao { get; set; }
    public Banco Banco { get; set; }
}
