﻿using System;

namespace ColabRH.Business.Models.Cadastros;

public class Departamento : Entity
{
    public Guid GrupoEconomicoId { get; set; }

    public string Nome { get; set; }
    public string CodigoMapeamento { get; set; }

    public GrupoEconomico GrupoEconomico { get; set; }    
}
