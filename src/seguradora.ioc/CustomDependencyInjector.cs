using Microsoft.Extensions.DependencyInjection;
using seguradora.domain.Abstractions.Repository;
using seguradora.domain.Abstractions.Service;
using seguradora.domain.ExternalServices;
using seguradora.domain.Services;
using seguradora.repository.Repository;
using System.Net.Http;

namespace seguradora.ioc
{
    public class CustomDependencyInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICoberturaService, CoberturaService>();
            services.AddScoped<ISeguradoService, SeguradoService>();
            services.AddScoped<ICotacaoService, CotacaoService>();
            services.AddScoped<ICoberturaRepository, CoberturaRepository>();
            services.AddScoped<ICidades, Cidades>();
            services.AddScoped<HttpClient>();
         
        }
    }
}
