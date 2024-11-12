using _5W2H.Application.Models;
using MediatR;

namespace _5W2H.Application.Commands.LeaderEvaluation.LeaderEvaluationCommands.CompleteLeaderEvaluation;

public class CompleteLeaderEvaluationCommand : IRequest<ResultViewModel<LeaderEvaluationViewModel>>
{
    public CompleteLeaderEvaluationCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}