using _5W2H.Application.Models;
using MediatR;

namespace _5W2H.Application.Queries.LeaderEvaluation.LeaderEvaluationQueries.GetSelfLeaderEvaluation;

public class GetSelfLeaderEvaluationQuery : IRequest<ResultViewModel<List<LeaderEvaluationViewModel>>>
{
    public GetSelfLeaderEvaluationQuery(int userId)
    {
        UserId = userId;
    }

    public int UserId { get; set; }
}