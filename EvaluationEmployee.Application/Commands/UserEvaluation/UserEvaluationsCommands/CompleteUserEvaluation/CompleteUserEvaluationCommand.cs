using _5W2H.Application.Models;
using MediatR;

namespace _5W2H.Application.Commands.UserEvaluation.UserEvaluationsCommands.CompleteUserEvaluation;

public class CompleteUserEvaluationCommand : IRequest<ResultViewModel<UserEvaluationViewModel>>
{
    public CompleteUserEvaluationCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}