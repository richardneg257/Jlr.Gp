using Jlr.Gp.Application.Contracts.Infrastructure;
using Jlr.Gp.Application.Features.Queries.GetDocumentByDni;
using MediatR;

namespace Jlr.Gp.Application.Features.Queries.GetDocumentByRuc;
public class GetDocumentByRucQueryHandler : IRequestHandler<GetDocumentByRucQuery, DocumentByRucDto?>
{
    private readonly IHttpDocumentService _httpDocumentService;

    public GetDocumentByRucQueryHandler(IHttpDocumentService httpDocumentService)
    {
        _httpDocumentService = httpDocumentService;
    }

    public async Task<DocumentByRucDto?> Handle(GetDocumentByRucQuery request, CancellationToken cancellationToken)
    {
        var documentByRuc = new DocumentByRucDto();
        var responseSap = await _httpDocumentService.GetDocumentFromSap(request.Ruc);
        if (responseSap is not null && responseSap.Codigo is not null)
        {
            documentByRuc.Ruc = responseSap.Codigo;
            documentByRuc.BusinessName = responseSap.Nombre;
        }
        else
        {
            var responseExternal = await _httpDocumentService.GetDocumentByRuc(request.Ruc);
            documentByRuc.Ruc = responseExternal.Ruc;
            documentByRuc.BusinessName = responseExternal.Name;
        }

        return documentByRuc;
    }
}
