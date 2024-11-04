using _5W2H.Application.Models;
using MediatR;

namespace _5W2H.Application.Commands.LeaderEvaluation.LeaderAvaliationCommands.CompleteLeaderEvaluation;

public class CompleteLeaderEvaluationHandler : IRequestHandler<CompleteLeaderEvaluationCommand, ResultViewModel<LeaderEvaluationViewModel>>
{
    public Task<ResultViewModel<LeaderEvaluationViewModel>> Handle(CompleteLeaderEvaluationCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}