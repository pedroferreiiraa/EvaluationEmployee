using _5W2H.Application.DTOs;
using _5W2H.Application.Models;
using _5W2H.Core.Enums;
using MediatR;

namespace _5W2H.Application.Commands.LeaderAvaliation.LeaderAvaliationCommands.InsertLeaderAvaliation;

public class InsertLeaderEvaluationCommand : IRequest<ResultViewModel<int>>
{
    public int LeaderId { get; set; }
    public int EvaluatorId { get; set; }
    public EvaluationStatusEnum Status { get; set; }
    public string DateReference { get; set; }
    public List<LeaderAnswerDto> LeaderAnswers { get; set; } = new List<LeaderAnswerDto>();

    public Core.Entities.LeaderEvaluation ToEntity()
    {
        var leaderAvaliation = new Core.Entities.LeaderEvaluation(LeaderId, EvaluatorId, Status, DateReference);
        foreach (var leaderAnswerDto in LeaderAnswers)
        {
            leaderAvaliation.AddAnswer(leaderAnswerDto.QuestionId, leaderAnswerDto.AnswerNumber);
        }
        return leaderAvaliation;
    }
    
}