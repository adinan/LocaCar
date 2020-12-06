using LocaCar.Api.Data;
using LocaCar.Business.Intefaces;
using LocaCar.Business.Notificacoes;
using LocaCar.Business.Services;
using LocaCar.Data.Context;
using LocaCar.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace LocaCar.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<ILocacaoRepository, LocacaoRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IVeiculoService, VeiculoService>();
            services.AddScoped<ILocacaoService, LocacaoService>();

            services.AddScoped<IFipeApi, FipeApi>();


            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();


            return services;
        }
    }
}
