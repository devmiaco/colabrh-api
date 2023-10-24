using ColabRH.Business.Models.Cadastros;
using System;

namespace ColabRH.Business.Models.Admissoes
{
    public class Admissao : Entity
    {
        public Guid GrupoEconomicoId { get; set; }
        public Guid EmpresaId { get; set; }
        public Guid? GradeId { get; set; }
        public Guid CargoId { get; set; }
        public Guid DepartamentoId { get; set; }
        public Guid VinculoId { get; set; }

        public string Nome { get; set; }
        public string EmailPessoal { get; set; }
        public decimal Salario { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime DataLimitePreenchimento { get; set; }

        public GrupoEconomico GrupoEconomico { get; set; }
        public Empresa Empresa { get; set; }
        public Grade Grade { get; set; }
        public Cargo Cargo { get; set; }
        public Departamento Departamento { get; set; }
        public Vinculo Vinculo { get; set; }
    }
}
