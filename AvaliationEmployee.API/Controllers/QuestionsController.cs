using _5W2H.Application.Commands.QuestionCommands.InsertQuestion;
using _5W2H.Application.Models;
using Azure;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace _5W2H.Api.Controllers;

[ApiController]
[Route("/api/questions")]
public class QuestionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public QuestionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // [HttpGet]
    // public async Task<IActionResult> Get()
    // {
    //     var query = new GetAllQuestionsQuery();
    //     var result = await _mediator.Send(query);
    //     
    //     return Ok(result);
    // }

    // [HttpGet("{id}")]
    // public async Task<IActionResult> GetById(int id)
    // {
    //     var query = new GetQuestionQuery(id);
    //     
    //     var question = await _mediator.Send(query);
    //
    //     if (question == null)
    //     {
    //         return NotFound();
    //     }
    //     
    //     return Ok(question);
    // }

    [HttpPost]
    public async Task<IActionResult> Post(InsertQuestionCommand command)
    {
        var result = await _mediator.Send(command);
        
        return Ok(result);
    }

    
}