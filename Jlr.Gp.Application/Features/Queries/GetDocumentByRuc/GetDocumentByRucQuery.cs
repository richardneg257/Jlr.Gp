using MediatR;

namespace Jlr.Gp.Application.Features.Queries.GetDocumentByRuc;
public class GetDocumentByRucQuery : IRequest<DocumentByRucDto?>
{
    public string Ruc { get; set; } = string.Empty;
}
