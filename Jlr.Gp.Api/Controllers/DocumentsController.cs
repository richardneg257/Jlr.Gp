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
        var response = await _mediator.Send(getDocumentByDniQuery);
        if(response is null) return NotFound("The client doesn't exist.");

        return response;
    }

    [HttpGet("ruc")]
    public async Task<ActionResult<DocumentByRucDto?>> GetByRuc([FromQuery] string ruc)
    {
        var getDocumentByRucQuery = new GetDocumentByRucQuery() { Ruc = ruc };
        var response = await _mediator.Send(getDocumentByRucQuery);
        if (response is null) return NotFound("The client doesn't exist.");

        return response;
    }

    [HttpGet("plate")]
    public async Task<ActionResult<CarByPlateDto?>> GetByPlate([FromQuery] string plate)
    {
        var getCarByPlateQuery = new GetCarByPlateQuery() { Plate = plate };
        var response = await _mediator.Send(getCarByPlateQuery);
        if (response is null) return NotFound("Plate doesn't exist.");

        return response;
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
