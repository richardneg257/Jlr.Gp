using MediatR;

namespace Jlr.Gp.Application.Features.Queries.GetDocumentByDni;
public class GetDocumentByDniQuery : IRequest<DocumentByDniDto?>
{
    public string Dni { get; set; } = string.Empty;
}
