using Jlr.Gp.Application.Features.Queries.GetDocumentByDni;

namespace Jlr.Gp.Application.Contracts.Infrastructure;
public interface IHttpDocumentService
{
    Task<DocumentDniDto?> GetDocumentByDni(string dni);
}
