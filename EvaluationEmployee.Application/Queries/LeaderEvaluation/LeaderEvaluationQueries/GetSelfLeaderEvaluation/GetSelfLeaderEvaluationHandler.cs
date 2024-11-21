using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.LeaderEvaluation.LeaderEvaluationQueries.GetSelfLeaderEvaluation;

public class GetSelfLeaderEvaluationHandler : IRequestHandler<GetSelfLeaderEvaluationQuery, ResultViewModel<List<LeaderEvaluationViewModel>>>
{
    private readonly ILeaderEvaluationRepository _leaderEvaluationRepository;

    public GetSelfLeaderEvaluationHandler(ILeaderEvaluationRepository leaderEvaluationRepository)
    {
        _leaderEvaluationRepository = leaderEvaluationRepository;
    }
    
    
    public async Task<ResultViewModel<List<LeaderEvaluationViewModel>>> Handle(GetSelfLeaderEvaluationQuery query, CancellationToken cancellationToken)
    {
        if (query == null) throw new ArgumentNullException(nameof(query));

        var leaderEvaluations = await _leaderEvaluationRepository.GetEvaluationsByLeaderIdAsync(query.UserId);

        if (leaderEvaluations == null || !leaderEvaluations.Any())
        {
            return ResultViewModel<List<LeaderEvaluationViewModel>>.Error("Nenhuma avaliação foi encontrada. ");
        }

        var evaluationViewModels = leaderEvaluations
            .Select(LeaderEvaluationViewModel.FromEntity)
            .ToList();

        return ResultViewModel<List<LeaderEvaluationViewModel>>.Success(evaluationViewModels);
    }
}