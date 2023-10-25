using System;

namespace ColabRH.Business.Models.Cadastros;

public class Municipio : Entity
{
    public Guid EstadoId { get; set; }

    public string CodigoIBGE { get; set; }
    public string Nome { get; set; }

    public Estado Estado { get; set; }
}
