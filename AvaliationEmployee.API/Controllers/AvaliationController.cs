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
    
   

    
}