using Jlr.Gp.Application.Contracts.Infrastructure;
using MediatR;

namespace Jlr.Gp.Application.Features.Queries.GetDocumentByDni;
public class GetDocumentByDniQueryHandler : IRequestHandler<GetDocumentByDniQuery, DocumentByDniDto?>
{
    private readonly IHttpDocumentService _httpDocumentService;

    public GetDocumentByDniQueryHandler(IHttpDocumentService httpDocumentService)
	{
        _httpDocumentService = httpDocumentService;
    }

    public async Task<DocumentByDniDto?> Handle(GetDocumentByDniQuery request, CancellationToken cancellationToken)
    {
        var documentByDni = new DocumentByDniDto();
        var responseSap = await _httpDocumentService.GetDocumentFromSap(request.Dni);
        if(responseSap is not null && responseSap.Codigo is not  null)
        {
            documentByDni.DocumentNumber = responseSap.Codigo;
            documentByDni.Name = responseSap.PrimerNombre;
            documentByDni.FatherLastName = responseSap.ApellidoPaterno;
            documentByDni.MotherLastName = responseSap.ApellidoMaterno;
            documentByDni.Email = responseSap.Email;
            documentByDni.Phone = responseSap.Celular;
        }
        else
        {
            var responseExternal = await _httpDocumentService.GetDocumentByDni(request.Dni);
            if(responseExternal is null) return null;

            documentByDni.DocumentNumber = responseExternal.Dni;
            documentByDni.Name = responseExternal.Name;
            documentByDni.FatherLastName = responseExternal.Fathers_LastName;
            documentByDni.MotherLastName = responseExternal.Mothers_LastName;
        }

        return documentByDni;
    }
}
