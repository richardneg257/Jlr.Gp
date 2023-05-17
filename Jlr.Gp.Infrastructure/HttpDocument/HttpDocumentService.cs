﻿using Jlr.Gp.Application.Contracts.Infrastructure;
using Jlr.Gp.Application.Models;
using System.Net.Http.Json;

namespace Jlr.Gp.Infrastructure.HttpDocument;
public class HttpDocumentService : IHttpDocumentService
{
    private readonly HttpClient _clientHttpSap;
    private readonly HttpClient _clientHttpExternal;

    public HttpDocumentService(IHttpClientFactory httpClientFactory)
    {
        _clientHttpSap = httpClientFactory.CreateClient("sap");
        _clientHttpExternal = httpClientFactory.CreateClient("external");
    }

    public async Task<DocumentFromSap?> GetDocumentFromSap(string documentNumber)
    {
        var response = await _clientHttpSap.GetFromJsonAsync<DocumentFromSap>($"SocioByDoc?numerodoc={documentNumber}");
        return response;
    }

    public async Task<DocumentDniData?> GetDocumentByDni(string dni)
    {
        var response = await _clientHttpExternal.GetFromJsonAsync<DocumentDni>($"dni?document={dni}");
        return response.Data;
    }
}
