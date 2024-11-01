using _5W2H.Application.Commands.UserQuestionCommands.InsertQuestion;
using _5W2H.Application.Models;
using _5W2H.Application.Queries.UserQuestionQueries.GetAllUserQuestions;
using Azure;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace _5W2H.Api.Controllers;

[ApiController]
[Route("/api/questions")]
public class UserQuestionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserQuestionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllQuestions()
    {
        var query = new GetAllUsersQuestionsQuery();
        var questions = await _mediator.Send(query);

        return Ok(questions);
    }

    [HttpPost]
    public async Task<IActionResult> Post(InsertQuestionCommand command)
    {
        var result = await _mediator.Send(command);
        
        return Ok(result);
    }

    
}