using System;
using System.Collections.Generic;

namespace ColabRH.Business.Models.Cadastros;

public class GrupoEconomico : Entity
{
    public string Nome { get; set; }
    public DateTime DataCadastro { get; set; }
    public bool Ativo { get; set; }

    //public IEnumerable<Empresa> Empresas { get; set; }

}
