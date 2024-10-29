using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using MediatR;

namespace _5W2H.Application.Commands.ProjectsCommands.StartProject;

public class StartAvaliationCommand : IRequest<ResultViewModel<Avaliation>>
{
    public StartAvaliationCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }    
}