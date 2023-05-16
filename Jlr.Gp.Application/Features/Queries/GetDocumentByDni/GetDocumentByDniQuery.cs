using MediatR;

namespace Jlr.Gp.Application.Features.Queries.GetDocumentByDni;
public class GetDocumentByDniQuery : IRequest<DocumentDniDto?>
{
    public string Dni { get; set; }
}
