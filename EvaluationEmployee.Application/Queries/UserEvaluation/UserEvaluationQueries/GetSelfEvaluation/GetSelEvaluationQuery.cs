using _5W2H.Application.Models;
using MediatR;

namespace _5W2H.Application.Queries.UserEvaluation.UserEvaluationQueries.GetSelfEvaluation;

public class GetSelfEvaluationQuery : IRequest<ResultViewModel<List<UserEvaluationViewModel>>>
{
    public int UserId { get; set; }

    public GetSelfEvaluationQuery(int userId)
    {
        UserId = userId;
    }
}