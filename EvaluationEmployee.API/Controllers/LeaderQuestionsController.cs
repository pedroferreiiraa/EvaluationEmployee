using _5W2H.Application.Commands.LeaderAvaliation.LeaderQuestionCommands.InsertLeaderQuestion;
using _5W2H.Application.Commands.LeaderEvaluation.LeaderEvaluationCommands.CompleteLeaderEvaluation;
using _5W2H.Application.Queries.LeaderAvaliation.LeaderQuestionQueries.GetAllLeaderQuestions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _5W2H.Api.Controllers;

[ApiController]
[Route("/api/leaderQuestions")]
public class LeaderQuestionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaderQuestionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllQuestions()
    {
        var query = new GetAllLeadersQuestionsQuery();
        var questions = await _mediator.Send(query);

        return Ok(questions);
    }

    [HttpPost]
    public async Task<IActionResult> Post(InsertLeaderQuestionCommand command)
    {
        var result = await _mediator.Send(command);
        
        return Ok(result);
    }

    
}