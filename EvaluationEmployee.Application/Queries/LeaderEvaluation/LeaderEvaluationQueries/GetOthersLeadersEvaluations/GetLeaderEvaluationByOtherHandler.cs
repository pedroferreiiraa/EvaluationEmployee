using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.LeaderEvaluation.LeaderEvaluationQueries.GetOthersLeadersEvaluations;

public class GetLeaderEvaluationByOtherHandler : IRequestHandler<GetLeaderEvaluationsByOtherQuery, ResultViewModel<List<LeaderEvaluationViewModel>>>
{
    private readonly ILeaderEvaluationRepository _leaderEvaluationRepository;

    public GetLeaderEvaluationByOtherHandler(ILeaderEvaluationRepository leaderEvaluationRepository)
    {
        _leaderEvaluationRepository = leaderEvaluationRepository;
    }
    
    public async Task<ResultViewModel<List<LeaderEvaluationViewModel>>> Handle(GetLeaderEvaluationsByOtherQuery request, CancellationToken cancellationToken)
    {
        var leaderEvaluations = await _leaderEvaluationRepository.GetEvaluationsByLeaderIdAsync(request.LeaderID);
        
        var evaluationViewModels = leaderEvaluations
            .Select(LeaderEvaluationViewModel.FromEntity)  
            .ToList();
        
        return new ResultViewModel<List<LeaderEvaluationViewModel>>(evaluationViewModels);
    }
}