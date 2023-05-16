using Jlr.Gp.Application.Contracts.Infrastructure;
using MediatR;

namespace Jlr.Gp.Application.Features.Queries.GetDocumentByDni;
public class GetDocumentByDniQueryHandler : IRequestHandler<GetDocumentByDniQuery, DocumentDniDto?>
{
    private readonly IHttpDocumentService _httpDocumentService;

    public GetDocumentByDniQueryHandler(IHttpDocumentService httpDocumentService)
	{
        _httpDocumentService = httpDocumentService;
    }

    public async Task<DocumentDniDto?> Handle(GetDocumentByDniQuery request, CancellationToken cancellationToken)
    {
        var response = await _httpDocumentService.GetDocumentByDni(request.Dni);
        return response;
    }
}
