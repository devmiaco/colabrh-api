using ColabRH.Api.Extensions;
using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Beneficios;
using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Notificacoes;
using ColabRH.Business.Services.Beneficios;
using ColabRH.Business.Services.Cadastros;
using ColabRH.Data.Context;
using ColabRH.Data.Repository.Beneficios;
using ColabRH.Data.Repository.Cadastros;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ColabRH.Api.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        services.AddScoped<ColabRHDbContext>();

        #region Cadastro Repository        
        services.AddScoped<IGrupoEconomicoRepository, GrupoEconomicoRepository>();
        services.AddScoped<IEmpresaRepository, EmpresaRepository>();
        services.AddScoped<IGradeRepository, GradeRepository>();
        services.AddScoped<ICargoRepository, CargoRepository>();
        services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
        services.AddScoped<ISindicatoRepository, SindicatoRepository>();
        services.AddScoped<IVinculoRepository, VinculoRepository>();
        services.AddScoped<ISituacaoRepository, SituacaoRepository>();
        services.AddScoped<IGrauParentescoRepository, GrauParentescoRepository>();
        services.AddScoped<IOperadoraRepository, OperadoraRepository>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IPlanoRepository, PlanoRepository>();
        #endregion

        #region Beneficio Repository
        services.AddScoped<IContratoBeneficioRepository, ContratoBeneficioRepository>();
        services.AddScoped<IContratoElegibilidadeRepository, ContratoElegibilidadeRepository>();
        services.AddScoped<IContratoElegibilidadeCargoRepository, ContratoElegibilidadeCargoRepository>();
        services.AddScoped<IContratoElegibilidadeGradeRepository, ContratoElegibilidadeGradeRepository>();
        services.AddScoped<IContratoGrauParentescoRepository, ContratoGrauParentescoRepository>();
        services.AddScoped<IContratoPlanoRepository, ContratoPlanoRepository>();
        services.AddScoped<IContratoSubestipulanteRepository, ContratoSubestipulanteRepository>();
        #endregion

        services.AddScoped<INotificador, Notificador>();

        #region Cadastro Service        
        services.AddScoped<IGrupoEconomicoService, GrupoEconomicoService>();
        services.AddScoped<IEmpresaService, EmpresaService>();
        services.AddScoped<IGradeService, GradeService>();
        services.AddScoped<ICargoService, CargoService>();
        services.AddScoped<IDepartamentoService, DepartamentoService>();
        services.AddScoped<ISindicatoService, SindicatoService>();
        services.AddScoped<IVinculoService, VinculoService>();
        services.AddScoped<ISituacaoService, SituacaoService>();
        services.AddScoped<IGrauParentescoService, GrauParentescoService>();
        services.AddScoped<IOperadoraService, OperadoraService>();
        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddScoped<IPlanoService, PlanoService>();
        #endregion

        #region Beneficio Service
        services.AddScoped<IContratoBeneficioService, ContratoBeneficioService>();
        services.AddScoped<IContratoElegibilidadeService, ContratoElegibilidadeService>();
        services.AddScoped<IContratoElegibilidadeCargoService, ContratoElegibilidadeCargoService>();
        services.AddScoped<IContratoElegibilidadeGradeService, ContratoElegibilidadeGradeService>();
        services.AddScoped<IContratoGrauParentescoService, ContratoGrauParentescoService>();
        services.AddScoped<IContratoPlanoService, ContratoPlanoService>();
        services.AddScoped<IContratoSubestipulanteService, ContratoSubestipulanteService>();
        #endregion

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IUser, AspNetUser>();

        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

        return services;
    }
}