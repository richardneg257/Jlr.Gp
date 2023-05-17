using Jlr.Gp.Application.Contracts.Infrastructure;
using Jlr.Gp.Infrastructure.HttpDocument;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

namespace Jlr.Gp.Infrastructure;
public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient("sap", cfg =>
        {
            cfg.BaseAddress = new Uri(configuration.GetValue<string>("EndpointSap:UriBase"));
        });

        services.AddHttpClient("external", cfg =>
        {
            cfg.BaseAddress = new Uri(configuration.GetValue<string>("EndpointExternal:UriBase"));
            cfg.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", configuration.GetValue<string>("EndpointExternal:Bearer"));
        });

        services.AddScoped<IHttpDocumentService, HttpDocumentService>();

        return services;
    }
}
