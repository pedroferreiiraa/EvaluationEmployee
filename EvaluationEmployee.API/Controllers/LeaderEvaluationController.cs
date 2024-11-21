using _5W2H.Application.Commands.LeaderAvaliation.LeaderAvaliationCommands.InsertLeaderAvaliation;
using _5W2H.Application.Commands.LeaderEvaluation.LeaderEvaluationCommands.CompleteLeaderEvaluation;
using _5W2H.Application.Queries.LeaderAvaliation.LeaderAvaliationQueries.GetAllLeaderAvaliations;
using _5W2H.Application.Queries.LeaderAvaliation.LeaderAvaliationQueries.GetLeaderAvaliationById;
using _5W2H.Application.Queries.LeaderEvaluation.LeaderEvaluationQueries.GetOthersLeadersEvaluations;
using _5W2H.Application.Queries.LeaderEvaluation.LeaderEvaluationQueries.GetSelfLeaderEvaluation;
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
    public async Task<IActionResult> Post(InsertLeaderEvaluationCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAvaliations()
    {
        var query = new GetAllLeaderEvaluationsQuery();
        var avaliations = await _mediator.Send(query);
        return Ok(avaliations);
    }

    [HttpGet("self/{userId}")]
    public async Task<IActionResult> GetLeaderAvaliations(int userId)
    {
        var query = new GetSelfLeaderEvaluationQuery(userId);
        var result = await _mediator.Send(query);

        if (result == null)
        {
            return NotFound(result.Message);
        }
        
        return Ok(result);
    }

    [HttpGet("others/{leaderId}")]
    public async Task<IActionResult> GetLeaderEvaluations(int leaderId)
    {
        var query = new GetLeaderEvaluationsByOtherQuery(leaderId);
        var result = await _mediator.Send(query);

        if (result == null)
        {
            return NotFound(result.Message);
        }
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAvaliationById(int id)
    {
        var query = new GetLeaderEvaluationByIdQuery(id);
        var avaliation = await _mediator.Send(query);
        return Ok(avaliation);
    }
    [HttpPut("{id}/complete")]
    public async Task<IActionResult> Complete(int id)
    {
        var coomand = new CompleteLeaderEvaluationCommand(id);
        var result  = await _mediator.Send(coomand);

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }
        
        return Ok(result);
    }

    
}