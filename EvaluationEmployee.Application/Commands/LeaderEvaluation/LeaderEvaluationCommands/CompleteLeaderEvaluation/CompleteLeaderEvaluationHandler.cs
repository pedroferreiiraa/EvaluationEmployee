using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.LeaderEvaluation.LeaderEvaluationCommands.CompleteLeaderEvaluation;

public class CompleteLeaderEvaluationHandler : IRequestHandler<CompleteLeaderEvaluationCommand, ResultViewModel<LeaderEvaluationViewModel>>
{
    private readonly ILeaderEvaluationRepository _leaderEvaluationRepository;
    
    public CompleteLeaderEvaluationHandler(ILeaderEvaluationRepository leaderEvaluationRepository)
    {
        _leaderEvaluationRepository = leaderEvaluationRepository;
    }
    
    
    public async Task<ResultViewModel<LeaderEvaluationViewModel>> Handle(CompleteLeaderEvaluationCommand request, CancellationToken cancellationToken)
    {
        var existingEvaluation = await _leaderEvaluationRepository.GetByIdAsync(request.Id);

        if (existingEvaluation == null)
        {
            return ResultViewModel<LeaderEvaluationViewModel>.Error("Avaliação não encontrada");
        }
        
        existingEvaluation.Complete();
        await _leaderEvaluationRepository.SaveChangesAsync();

        return ResultViewModel<LeaderEvaluationViewModel>.Success(LeaderEvaluationViewModel.FromEntity(existingEvaluation));

    }
}