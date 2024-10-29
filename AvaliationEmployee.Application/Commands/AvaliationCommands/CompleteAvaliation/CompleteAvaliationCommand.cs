using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using MediatR;

namespace _5W2H.Application.Commands.ProjectsCommands.CompleteProject;

public class CompleteAvaliationCommand : IRequest<ResultViewModel<Avaliation>>
{
    public CompleteAvaliationCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}