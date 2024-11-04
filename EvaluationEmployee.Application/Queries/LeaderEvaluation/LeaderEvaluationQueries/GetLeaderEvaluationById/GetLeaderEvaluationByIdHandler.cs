using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.LeaderAvaliation.LeaderAvaliationQueries.GetLeaderAvaliationById;

public class GetLeaderEvaluationByIdHandler : IRequestHandler<GetLeaderAvaliationByIdQuery, ResultViewModel<LeaderEvaluationViewModel>>
{
    private readonly ILeaderEvaluationRepository _repository;

    public GetLeaderEvaluationByIdHandler(ILeaderEvaluationRepository repository)
    {
        _repository = repository;
    }
    
    
    
    public async Task<ResultViewModel<LeaderEvaluationViewModel>> Handle(GetLeaderAvaliationByIdQuery request, CancellationToken cancellationToken)
    {
        var leaderAvaliation = await _repository.GetByIdAsync(request.Id);

        if (leaderAvaliation == null)
        {
            return ResultViewModel<LeaderEvaluationViewModel>.Error("Avaliação não encontrada");
        }

        var model = LeaderEvaluationViewModel.FromEntity(leaderAvaliation);
        
        return ResultViewModel<LeaderEvaluationViewModel>.Success(model);
    }
}