using ColabRH.Api.Extensions;
using ColabRH.Business.Interfaces;
using ColabRH.Business.Interfaces.Admissoes;
using ColabRH.Business.Interfaces.Beneficios;
using ColabRH.Business.Interfaces.Cadastros;
using ColabRH.Business.Interfaces.Funcionarios;
using ColabRH.Business.Notificacoes;
using ColabRH.Business.Services.Admissoes;
using ColabRH.Business.Services.Beneficios;
using ColabRH.Business.Services.Cadastros;
using ColabRH.Business.Services.Funcionarios;
using ColabRH.Data.Context;
using ColabRH.Data.Repository.Admissoes;
using ColabRH.Data.Repository.Beneficios;
using ColabRH.Data.Repository.Cadastros;
using ColabRH.Data.Repository.Funcionarios;
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
        services.AddScoped<IEstadoMunicipioRepository, EstadoMunicipioRepository>();
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

        #region Funcionario Repository
        services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
        services.AddScoped<IFuncionarioBeneficioRepository, FuncionarioBeneficioRepository>();
        services.AddScoped<IDependenteRepository, DependenteRepository>();
        services.AddScoped<IDependenteBeneficioRepository, DependenteBeneficioRepository>();
        #endregion

        #region Admissao Repository
        services.AddScoped<IAdmissaoRepository, AdmissaoRepository>();
        services.AddScoped<IAdmissaoDadosBancariosRepository, AdmissaoDadosBancariosRepository>();
        services.AddScoped<IAdmissaoDadosPessoaisRepository, AdmissaoDadosPessoaisRepository>();
        services.AddScoped<IAdmissaoDependenteRepository, AdmissaoDependenteRepository>();
        services.AddScoped<IAdmissaoDocumentoRepository, AdmissaoDocumentoRepository>();
        services.AddScoped<IAdmissaoEnderecoRepository, AdmissaoEnderecoRepository>();
        services.AddScoped<IAdmissaoFormacaoAcademicaRepository, AdmissaoFormacaoAcademicaRepository>();
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

        #region Funcionario Service
        services.AddScoped<IFuncionarioService, FuncionarioService>();
        services.AddScoped<IFuncionarioBeneficioService, FuncionarioBeneficioService>();
        services.AddScoped<IDependenteService, DependenteService>();
        services.AddScoped<IDependenteBeneficioService, DependenteBeneficioService>();
        #endregion

        #region Admissao Service
        services.AddScoped<IAdmissaoService, AdmissaoService>();
        services.AddScoped<IAdmissaoDadosBancariosService, AdmissaoDadosBancariosService>();
        services.AddScoped<IAdmissaoDadosPessoaisService, AdmissaoDadosPessoaisService>();
        services.AddScoped<IAdmissaoDependenteService, AdmissaoDependenteService>();
        services.AddScoped<IAdmissaoDocumentoService, AdmissaoDocumentoService>();
        services.AddScoped<IAdmissaoEnderecoService, AdmissaoEnderecoService>();
        services.AddScoped<IAdmissaoFormacaoAcademicaService, AdmissaoFormacaoAcademicaService>();
        #endregion

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IUser, AspNetUser>();

        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

        return services;
    }
}