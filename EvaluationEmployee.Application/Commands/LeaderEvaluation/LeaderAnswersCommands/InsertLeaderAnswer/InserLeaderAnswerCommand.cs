using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using MediatR;

namespace _5W2H.Application.Commands.LeaderAvaliation.LeaderAnswersCommands.InsertLeaderAnswer;

public class InserLeaderAnswerCommand : IRequest<ResultViewModel<int>>
{
    public int LeaderAvaliationId { get; set; }
    public int LeaderQuestionId { get; set; }
    public int LeaderAnswerNumber { get; set; }
    
    public LeaderAnswer ToEntity()
        => new (LeaderAvaliationId, LeaderQuestionId, LeaderAnswerNumber);
}