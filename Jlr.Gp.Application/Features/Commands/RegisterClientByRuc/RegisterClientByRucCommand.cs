using MediatR;

namespace Jlr.Gp.Application.Features.Commands.RegisterClientByRuc;
public class RegisterClientByRucCommand : IRequest
{
    public string Ruc { get; set; } = string.Empty;
    public string BusinessName { get; set; } = string.Empty;
    public string Dni { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}
