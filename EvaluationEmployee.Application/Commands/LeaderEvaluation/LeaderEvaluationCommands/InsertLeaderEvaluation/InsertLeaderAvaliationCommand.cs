using _5W2H.Application.DTOs;
using _5W2H.Application.Models;
using _5W2H.Core.Enums;
using MediatR;

namespace _5W2H.Application.Commands.LeaderAvaliation.LeaderAvaliationCommands.InsertLeaderAvaliation;

public class InsertLeaderAvaliationCommand : IRequest<ResultViewModel<int>>
{
    public int LeaderId { get; set; }
    public int EvaluatorId { get; set; }
    public EvaluationStatusEnum Status { get; set; }
    public List<LeaderAnswerDto> LeaderAnswers { get; set; } = new List<LeaderAnswerDto>();

    public Core.Entities.LeaderAvaliation ToEntity()
    {
        var leaderAvaliation = new Core.Entities.LeaderAvaliation(LeaderId, EvaluatorId, Status);
        foreach (var leaderAnswerDto in LeaderAnswers)
        {
            leaderAvaliation.AddAnswer(leaderAnswerDto.QuestionId, leaderAnswerDto.AnswerNumber);
        }
        return leaderAvaliation;
    }
    
}