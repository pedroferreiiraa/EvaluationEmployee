using _5W2H.Application.Commands.LeaderAvaliation.LeaderAvaliationCommands.InsertLeaderAvaliation;
using _5W2H.Application.Queries.LeaderAvaliation.LeaderAvaliationQueries.GetAllLeaderAvaliations;
using _5W2H.Application.Queries.LeaderAvaliation.LeaderAvaliationQueries.GetLeaderAvaliationById;
using _5W2H.Application.Queries.UserAvaliationQueries.GetAllUsersAvaliations;
using _5W2H.Application.Queries.UserAvaliationQueries.GetUserAvaliationById;
using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace _5W2H.Api.Controllers;

[ApiController]
[Route("api/leaderAvaliations")]
public class LeaderEvaluationController : ControllerBase
{
    private readonly IMediator _mediator;
    public LeaderEvaluationController(IMediator mediator)
    {
        _mediator = mediator;
            
    }

    [HttpPost]
    public async Task<IActionResult> Post(InsertLeaderAvaliationCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAvaliations()
    {
        var query = new GetAllLeaderAvaliationsQuery();
        var avaliations = await _mediator.Send(query);
        return Ok(avaliations);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAvaliationById(int id)
    {
        var query = new GetLeaderAvaliationByIdQuery(id);
        var avaliation = await _mediator.Send(query);
        return Ok(avaliation);
    }

    
}