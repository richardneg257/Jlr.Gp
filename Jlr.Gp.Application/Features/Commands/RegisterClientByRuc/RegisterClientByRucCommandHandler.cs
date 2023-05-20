using Jlr.Gp.Application.Contracts.Infrastructure;
using Jlr.Gp.Application.Models;
using MediatR;

namespace Jlr.Gp.Application.Features.Commands.RegisterClientByRuc;
public class RegisterClientByRucCommandHandler : IRequestHandler<RegisterClientByRucCommand>
{
    private readonly IHttpDocumentService _httpDocumentService;

    public RegisterClientByRucCommandHandler(IHttpDocumentService httpDocumentService)
    {
        _httpDocumentService = httpDocumentService;
    }

    public async Task Handle(RegisterClientByRucCommand request, CancellationToken cancellationToken)
    {
        // Register with RUC
        var clientWithRuc = new ClientInfo();

        var responseRuc = await _httpDocumentService.GetDocumentFromSap(request.Ruc);
        if (responseRuc is null || responseRuc.Codigo is null)
        {
            clientWithRuc.Action = "CREATE";
        }
        else
        {
            clientWithRuc.Action = "UPDATE";
        }

        clientWithRuc.NroDocumento = request.Ruc;
        clientWithRuc.Nombre = request.BusinessName;
        clientWithRuc.Codigo = $"C{request.Ruc}";

        await _httpDocumentService.RegisterClient(clientWithRuc);

        // Register Contact with DNI
        var clientWithDni = new ClientInfo();

        var responseDni = await _httpDocumentService.GetDocumentFromSap(request.Dni);
        if (responseDni is null || responseDni.Codigo is null)
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

        await _httpDocumentService.RegisterClient(clientWithDni);
    }
}
