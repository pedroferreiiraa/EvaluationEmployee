using _5W2H.Application.Commands.UserAvaliationsCommands.InsertUserAvaliation;
using _5W2H.Application.Queries.UserAvaliationQueries.GetAllUsersAvaliations;
using _5W2H.Application.Queries.UserAvaliationQueries.GetUserAvaliationById;
using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace _5W2H.Api.Controllers;

[ApiController]
[Route("api/userAvaliations")]
public class UserAvaliationController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserAvaliationController(IMediator mediator)
    {
        _mediator = mediator;
            
    }

    [HttpPost]
    public async Task<IActionResult> Post(InsertUserAvaliationCommand command)
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAvaliationById(int id)
    {
        var query = new GetUserAvaliationByIdQuery(id);
        var avaliation = await _mediator.Send(query);
        return Ok(avaliation);
    }

    
}