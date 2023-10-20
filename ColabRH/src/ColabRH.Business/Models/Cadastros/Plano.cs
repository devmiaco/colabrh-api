using ColabRH.Business.Models.Enums;
using System;

namespace ColabRH.Business.Models.Cadastros;

public class Plano : Entity
{
    public Guid OperadoraId { get; set; }
    public Guid ProdutoId { get; set; }

    public string Nome { get; set; }
    public string Codigo { get; set; }
    public TipoPlanoAcomodacao TipoAcomodacao { get; set; }
    public TipoPlanoAbrangencia TipoAbrangencia { get; set; }
    public string Descricao { get; set; }

    public Operadora Operadora { get; set; }
    public Produto Produto { get; set; }
}
