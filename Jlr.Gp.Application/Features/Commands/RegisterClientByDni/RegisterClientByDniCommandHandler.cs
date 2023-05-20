using Jlr.Gp.Application.Contracts.Infrastructure;
using Jlr.Gp.Application.Helpers;
using Jlr.Gp.Application.Models;
using MediatR;

namespace Jlr.Gp.Application.Features.Commands.RegisterClientByDni;
public class RegisterClientByDniCommandHandler : IRequestHandler<RegisterClientByDniCommand>
{
    private readonly IHttpDocumentService _httpDocumentService;

    public RegisterClientByDniCommandHandler(IHttpDocumentService httpDocumentService)
    {
        _httpDocumentService = httpDocumentService;
    }

    public async Task Handle(RegisterClientByDniCommand request, CancellationToken cancellationToken)
    {
        var clientWithDni = new ClientWithDni();

        var response = await _httpDocumentService.GetDocumentFromSap(request.Dni);
        if (response is null || response.Codigo is null)
        {
            clientWithDni.Action = "CREATE";
        }
        else
        {
            clientWithDni.Action = "UPDATE";
        }

        Helpers.Helpers.SplitLastName(request.LastName, out string fatherLastName, out string motherLastName);

        clientWithDni.NroDocumento = request.Dni;
        clientWithDni.Nombre = request.Name;
        clientWithDni.ApellidoPaterno = fatherLastName;
        clientWithDni.ApellidoMaterno = motherLastName;
        clientWithDni.Correo = request.Email;
        clientWithDni.Celular = request.Phone;
        clientWithDni.Telefono = request.Phone;
        clientWithDni.Codigo = $"C{request.Dni}";

        await _httpDocumentService.RegisterClientByDni(clientWithDni);
    }
}
