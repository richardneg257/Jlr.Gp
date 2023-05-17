using MediatR;

namespace Jlr.Gp.Application.Features.Queries.GetCarByPlate;
public class GetCarByPlateQuery : IRequest<CarByPlateDto?>
{
    public string Plate { get; set; } = string.Empty;
}
