using Jlr.Gp.Application.Contracts.Infrastructure;
using Jlr.Gp.Application.Features.Queries.GetDocumentByDni;
using System.Net.Http.Json;

namespace Jlr.Gp.Infrastructure.HttpDocument;
public class HttpDocumentService : IHttpDocumentService
{
    private readonly HttpClient _clientHttpDocuments;

    public HttpDocumentService(IHttpClientFactory httpClientFactory)
    {
        _clientHttpDocuments = httpClientFactory.CreateClient("documents");
    }

    public async Task<DocumentDniDto?> GetDocumentByDni(string dni)
    {
        var response = await _clientHttpDocuments.GetFromJsonAsync<DocumentDniDto>($"dni?document={dni}");
        return response;
    }
}
