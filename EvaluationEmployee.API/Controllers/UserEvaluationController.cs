using _5W2H.Application.Commands.UserAvaliation.UserAvaliationsCommands.InsertUserAvaliation;
using _5W2H.Application.Commands.UserEvaluation.UserEvaluationsCommands.CompleteUserEvaluation;
using _5W2H.Application.Queries.UserAvaliationQueries.GetAllUsersAvaliations;
using _5W2H.Application.Queries.UserAvaliationQueries.GetUserAvaliationById;
using _5W2H.Application.Queries.UserEvaluation.UserEvaluationQueries.GetOthersEvaluations;
using _5W2H.Application.Queries.UserEvaluation.UserEvaluationQueries.GetSelfEvaluation;
using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace _5W2H.Api.Controllers;

[ApiController]
[Route("api/userAvaliations")]
public class UserEvaluationController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserEvaluationController(IMediator mediator)
    {
        _mediator = mediator;
            
    }

    [HttpPost]
    public async Task<IActionResult> Post(InsertUserEvaluationCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAvaliations()
    {
        var query = new GetAllEvaluationsQuery();
        var avaliations = await _mediator.Send(query);
        return Ok(avaliations);
    }
    
    [HttpGet("self/{userId}")]
    public async Task<IActionResult> GetSelfEvaluation(int userId)
    {
        var query = new GetSelfEvaluationQuery(userId);
        var result = await _mediator.Send(query);

        if (result == null)
            return NotFound(result.Message);

        return Ok(result);
    }
    
    [HttpGet("others/{employeeId}")]
    public async Task<IActionResult> GetEvaluationsByOthers(int employeeId)
    {
        var query = new GetEvaluationsByOthersQuery(employeeId);
        var result = await _mediator.Send(query);

        if (result.Data == null || !result.Data.Any())
        {
            return NotFound("No evaluations found.");
        }

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAvaliationById(int id)
    {
        var query = new GetUserEvaluationByIdQuery(id);
        var avaliation = await _mediator.Send(query);
        return Ok(avaliation);
    }

    [HttpPut("{id}/complete")]
    public async Task<IActionResult> Complete(int id)
    {
        var coomand = new CompleteUserEvaluationCommand(id);
        var result  = await _mediator.Send(coomand);

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }
        
        return Ok(result);
    }
    
}