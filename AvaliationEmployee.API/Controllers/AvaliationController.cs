using _5W2H.Application.Commands.ProjectsCommands.CompleteProject;
using _5W2H.Application.Commands.ProjectsCommands.InsertProject;
using _5W2H.Application.Commands.ProjectsCommands.StartProject;
using _5W2H.Application.Queries.ProjectQueries.GetAllProjects;
using _5W2H.Application.Queries.ProjectQueries.GetProjectById;
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

    [HttpGet]
    public async Task<IActionResult> Get(string search = "", int pageNumber = 1, int pageSize = 10, int status = -1)
    {
        
        var query = new GetAllAvaliationsQuery(search, pageNumber, pageSize, status);
        var result = await _mediator.Send(query);

        
        if (result.IsSuccess)
        {
            return Ok(new
            {
                data = result.Data.Items, // Lista de projetos
                totalItems = result.Data.TotalItems, // Total de projetos encontrados
                totalPages = result.Data.TotalPages, // Número total de páginas
                pageNumber = result.Data.PageNumber, // Página atual
                pageSize = result.Data.PageSize // Tamanho da página
            });
        }
        else
        {
            return BadRequest(result.Message);
        }
    }

    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetProjectByIdQuery(id);
        var result = await _mediator.Send(query);

        if (!result.IsSuccess || result.Data == null)
        {
            return NotFound(result.Message);
        }

        return Ok(result.Data);
    }
    
    
    
    [HttpPost]
    public async Task<IActionResult> Post(InsertAvaliationCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}")]
 
    
    [HttpPut("{id}/start")]
    public async Task<IActionResult> Start(int id, [FromBody] StartAvaliationCommand command)
    {
        if (command.Id != id)
        {
            return BadRequest(new { message = "O ID no corpo da requisição não coincide com o ID da URL." });
        }
    
        var result = await _mediator.Send(command);
    
        if (!result.IsSuccess)
        {
            return BadRequest(new { message = result.Message });
        }
        
        return Ok(new { isSuccess = true, message = "Projeto iniciado com sucesso." });
    }
    
    [HttpPut("{id}/complete")]
    public async Task<IActionResult> Complete(int id)
    {
        var command = new CompleteAvaliationCommand(id);
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(new { message = result.Message });
        }
        
        return Ok(new { isSuccess = true, message = "Projeto completado com sucesso." });
    }
    
   


    
}