using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using MediatR;

namespace _5W2H.Application.Commands.LeaderAvaliation.LeaderQuestionCommands.InsertLeaderQuestion;

public class InsertLeaderQuestionCommand : IRequest<ResultViewModel<int>>
{
    public string Text { get; set; }
    public string Topic { get; set; }
    
    public LeaderQuestion ToEntity()
        => new (Text , Topic);

    
}