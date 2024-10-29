using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using _5W2H.Core.Enums;
using MediatR;

namespace _5W2H.Application.Commands.ProjectsCommands.InsertProject;

public class InsertAvaliationCommand : IRequest<ResultViewModel<int>>
{
    public int ColaboradorId { get; private set; } 
    public int AvaliadorId { get; private set; }
    public AvaliationStatusEnum Status { get; private set; }
    public IList<Answer> Answers { get; private set; } 
    public IList<Question> Questions { get; private set;}
    
    public Avaliation ToEntity()
        => new (ColaboradorId, AvaliadorId, Status, Answers, Questions);
}