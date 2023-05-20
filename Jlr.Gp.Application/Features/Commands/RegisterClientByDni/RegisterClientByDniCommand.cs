using MediatR;

namespace Jlr.Gp.Application.Features.Commands.RegisterClientByDni;
public class RegisterClientByDniCommand : IRequest
{
    public string Dni { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}
