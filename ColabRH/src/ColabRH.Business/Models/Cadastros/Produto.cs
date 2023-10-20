using ColabRH.Business.Models.Enums;
using System;

namespace ColabRH.Business.Models.Cadastros;

public class Produto : Entity
{
    public Guid OperadoraId { get; set; }

    public string Nome { get; set; }
    public TipoProduto TipoProduto  { get; set; }

    public Operadora Operadora { get; set; }
}
