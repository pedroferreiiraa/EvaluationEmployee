using _5W2H.Application.Models;
using MediatR;

namespace _5W2H.Application.Queries.LeaderAvaliation.LeaderAnswersQueries.GetAllLeaderAnswers;

public class GetAllLeaderAnswersQuery : IRequest<List<LeaderAnswerViewModel>>
{
    public GetAllLeaderAnswersQuery(string query)
    {
        Query = query;
    }
    
    public string Query { get; private set; }
}