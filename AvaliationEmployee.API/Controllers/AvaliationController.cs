using _5W2H.Application.Commands.AvaliationsCommands.InsertAvaliation;
using _5W2H.Application.Queries.AvaliationQueries.GetAllAvaliations;
using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace _5W2H.Api.Controllers;

[ApiController]
[Route("api/avaliations")]
public class AvaliationController : ControllerBase
{
    private readonly IMediator _mediator;
    public AvaliationController(IMediator mediator)
    {
        _mediator = mediator;
            
    }

    [HttpPost]
    public async Task<IActionResult> Post(InsertAvaliationCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAvaliations()
    {
        var query = new GetAllAvaliationsQuery();
        var avaliations = await _mediator.Send(query);
        return Ok(avaliations);
    }
    
}