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
        services.AddHttpClient("documents", cfg =>
        {
            cfg.BaseAddress = new Uri(configuration.GetValue<string>("EndpointDocuments:UriBase"));
            cfg.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", configuration.GetValue<string>("EndpointDocuments:Bearer"));
        });

        services.AddScoped<IHttpDocumentService, HttpDocumentService>();

        return services;
    }
}
