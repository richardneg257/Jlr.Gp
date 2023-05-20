using Jlr.Gp.Application.Contracts.Infrastructure;
using MediatR;

namespace Jlr.Gp.Application.Features.Queries.GetCarByPlate;
public class GetCarByPlateQueryHandler : IRequestHandler<GetCarByPlateQuery, CarByPlateDto?>
{
    private readonly IHttpDocumentService _httpDocumentService;

    public GetCarByPlateQueryHandler(IHttpDocumentService httpDocumentService)
    {
        _httpDocumentService = httpDocumentService;
    }

    public async Task<CarByPlateDto?> Handle(GetCarByPlateQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var responseExternal = await _httpDocumentService.GetCarByPlate(request.Plate);
            return new CarByPlateDto()
            {
                Plate = responseExternal.Plate,
                SerialNumber = responseExternal.Serial_Number,
                Brand = responseExternal.Brand,
                Model = responseExternal.Model,
                Motor = responseExternal.Motor
            };
        }
        catch(Exception ex)
        {
            return null;
        }
    }
}
