using System;
using System.Collections;
using System.Collections.Generic;

namespace ColabRH.Business.Models.Cadastros;

public class Grade : Entity
{
    public Guid GrupoEconomicoId { get; set; }

    public string Nome { get; set; }
    public string CodigoMapeamento { get; set; }

    public GrupoEconomico GrupoEconomico { get; set; }
    public IEnumerable<Cargo> Cargos { get; set; }
}
