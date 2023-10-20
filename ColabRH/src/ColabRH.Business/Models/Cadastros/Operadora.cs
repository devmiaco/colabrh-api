using System;

namespace ColabRH.Business.Models.Cadastros;

public class Operadora : Entity
{
    public Guid GrupoEconomicoId { get; set; }

    public string Cnpj { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }

    public GrupoEconomico GrupoEconomico { get; set; }
}
