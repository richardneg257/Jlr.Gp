using Jlr.Gp.Application.Features.Queries.GetDocumentByDni;
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

    [HttpGet]
    public async Task<ActionResult<DocumentByDniDto?>> GetByDni([FromQuery] string dni)
    {
        var getDocumentByDniQuery = new GetDocumentByDniQuery() { Dni = dni };
        return await _mediator.Send(getDocumentByDniQuery);
    }
}
