using _5W2H.Application.Commands.AnswersCommands.InsertAnswer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _5W2H.Api.Controllers;


[ApiController]
[Route("api/answer")]
public class AnswersController : ControllerBase
{
    private readonly IMediator _mediator;

    public AnswersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("{id}/answer")]
    public async Task<IActionResult> Post(InsertAnswerCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    
}