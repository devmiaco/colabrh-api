using System;

namespace ColabRH.Business.Models.Cadastros;

public class Empresa : Entity
{
    public Guid GrupoEconomicoId { get; set; }

    public string Cnpj { get; set; }
    public string RazaoSocial { get; set; }
    public string NomeFantasia { get; set; }
    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Municipio { get; set; }
    public string Uf { get; set; }

    public GrupoEconomico GrupoEconomico { get; set; }
}
