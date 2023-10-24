using ColabRH.Business.Models.Beneficios;
using ColabRH.Business.Models.Cadastros;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ColabRH.Data.Context;

public class ColabRHDbContext : DbContext
{
    public ColabRHDbContext(DbContextOptions<ColabRHDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;
    }

    #region Cadastros    
    public DbSet<GrupoEconomico> GruposEconomicos { get; set; }
    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Cargo> Cargos { get; set; }
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<Sindicato> Sindicatos { get; set; }
    public DbSet<Vinculo> Vinculos { get; set; }
    public DbSet<Situacao> Situacoes { get; set; }
    public DbSet<GrauParentesco> GrausParentesco { get; set; }
    public DbSet<Operadora> Operadoras { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Plano> Planos { get; set; }
    #endregion

    #region Beneficios    
    public DbSet<ContratoBeneficio> ContratosBeneficio { get; set; }
    public DbSet<ContratoElegibilidade> ContratosElegibilidade { get; set; }
    public DbSet<ContratoElegibilidadeCargo> ContratosElegibilidadeCargo { get; set; }
    public DbSet<ContratoElegibilidadeGrade> ContratosElegibilidadeGrade { get; set; }
    public DbSet<ContratoGrauParentesco> ContratosGrauParentesco { get; set; }
    public DbSet<ContratoPlano> ContratosPlano { get; set; }
    public DbSet<ContratoSubestipulante> ContratosSubestipulante { get; set; }
    #endregion

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("DataCadastro").CurrentValue = DateTime.Now;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("DataCadastro").IsModified = false;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
