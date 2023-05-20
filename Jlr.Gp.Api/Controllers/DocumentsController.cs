using Jlr.Gp.Application.Features.Commands.RegisterClientByDni;
using Jlr.Gp.Application.Features.Commands.RegisterClientByRuc;
using Jlr.Gp.Application.Features.Queries.GetCarByPlate;
using Jlr.Gp.Application.Features.Queries.GetDocumentByDni;
using Jlr.Gp.Application.Features.Queries.GetDocumentByRuc;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jlr.Gp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DocumentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DocumentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("dni")]
    public async Task<ActionResult<DocumentByDniDto?>> GetByDni([FromQuery] string dni)
    {
        var getDocumentByDniQuery = new GetDocumentByDniQuery() { Dni = dni };
        return await _mediator.Send(getDocumentByDniQuery);
    }

    [HttpGet("ruc")]
    public async Task<ActionResult<DocumentByRucDto?>> GetByRuc([FromQuery] string ruc)
    {
        var getDocumentByRucQuery = new GetDocumentByRucQuery() { Ruc = ruc };
        return await _mediator.Send(getDocumentByRucQuery);
    }

    [HttpGet("plate")]
    public async Task<ActionResult<CarByPlateDto?>> GetByPlate([FromQuery] string plate)
    {
        var getCarByPlateQuery = new GetCarByPlateQuery() { Plate = plate };
        return await _mediator.Send(getCarByPlateQuery);
    }

    [HttpPost("dni")]
    public async Task<ActionResult> RegisterByDni([FromBody] RegisterClientByDniCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPost("ruc")]
    public async Task<ActionResult> RegisterByRuc([FromBody] RegisterClientByRucCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}
