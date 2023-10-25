using ColabRH.Business.Models.Cadastros;
using System;

namespace ColabRH.Business.Models.Admissoes;

public class AdmissaoEndereco : Entity
{
    public Guid AdmissaoId { get; set; }

    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public Guid MunicipioId { get; set; }
    public Guid EstadoId { get; set; }

    public string ComprovanteResidencia { get; set; }
    public string TelefoneResidencial { get; set; }
    public string TelefoneCelular { get; set; }
    public string EmailPessoal { get; set; }

    public Admissao Admissao { get; set; }
    public Estado Estado { get; set; }
    public Municipio Municipio { get; set; }
}
