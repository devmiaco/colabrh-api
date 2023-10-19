using ColabRH.Api.Extensions;
using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Notificacoes;
using ColabRH.Business.Services.Cadastros;
using ColabRH.Data.Context;
using ColabRH.Data.Repository;
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
        services.AddScoped<IGrupoEconomicoRepository, GrupoEconomicoRepository>();
        services.AddScoped<IEmpresaRepository, EmpresaRepository>();
        services.AddScoped<IGradeRepository, GradeRepository>();
        services.AddScoped<ICargoRepository, CargoRepository>();

        services.AddScoped<INotificador, Notificador>();
        services.AddScoped<IGrupoEconomicoService, GrupoEconomicoService>();
        services.AddScoped<IEmpresaService, EmpresaService>();
        services.AddScoped<IGradeService, GradeService>();
        services.AddScoped<ICargoService, CargoService>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IUser, AspNetUser>();

        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

        return services;
    }
}