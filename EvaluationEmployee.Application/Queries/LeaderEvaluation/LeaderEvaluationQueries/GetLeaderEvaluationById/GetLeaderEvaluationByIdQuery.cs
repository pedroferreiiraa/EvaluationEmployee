using _5W2H.Application.Models;
using MediatR;

namespace _5W2H.Application.Queries.LeaderAvaliation.LeaderAvaliationQueries.GetLeaderAvaliationById;

public class GetLeaderEvaluationByIdQuery : IRequest<ResultViewModel<LeaderEvaluationViewModel>>
{
    public GetLeaderEvaluationByIdQuery(int id)
    {
        Id = id;
    }
    
    public int Id { get; set; }
}