using _5W2H.Application.Models;
using MediatR;

namespace _5W2H.Application.Queries.LeaderEvaluation.LeaderEvaluationQueries.GetOthersLeadersEvaluations;

public class GetLeaderEvaluationsByOtherQuery : IRequest<ResultViewModel<List<LeaderEvaluationViewModel>>>
{
    public int LeaderID { get; set;  }

    public GetLeaderEvaluationsByOtherQuery(int leaderID)
    {
        LeaderID = leaderID;
    }
}