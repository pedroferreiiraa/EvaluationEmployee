using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using MediatR;

namespace _5W2H.Application.Commands.AvaliationsCommands.InsertAvaliation;

public class InsertAvaliationCommand : IRequest<ResultViewModel<int>>
{
    public int EmployeeId { get; set; }
    public int AvaliadorId { get; set; }
    public List<int> QuestionIds { get; set; } = new List<int>(); 
    public List<int> AnswerIds { get; set; } = new List<int>();  
    
    public Avaliation ToEntity(ICollection<Question> questions, ICollection<Answer> answers)
        => new(EmployeeId, AvaliadorId, answers, questions);
}