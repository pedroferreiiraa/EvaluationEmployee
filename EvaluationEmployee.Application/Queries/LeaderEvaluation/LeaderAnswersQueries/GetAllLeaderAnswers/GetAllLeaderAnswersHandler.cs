using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.LeaderAvaliation.LeaderAnswersQueries.GetAllLeaderAnswers;

public class GetAllLeaderAnswersHandler : IRequestHandler<GetAllLeaderAnswersQuery, List<LeaderAnswerViewModel>>
{
    
    private readonly ILeaderAnswerRepository _leaderAnswerRepository;

    public GetAllLeaderAnswersHandler(ILeaderAnswerRepository leaderAnswerRepository)
    {
        _leaderAnswerRepository = leaderAnswerRepository;
    }
    
    public async Task<List<LeaderAnswerViewModel>> Handle(GetAllLeaderAnswersQuery request, CancellationToken cancellationToken)
    {
        var anwers = await _leaderAnswerRepository.GetAllAsync();

        return new List<LeaderAnswerViewModel>();
    }
}