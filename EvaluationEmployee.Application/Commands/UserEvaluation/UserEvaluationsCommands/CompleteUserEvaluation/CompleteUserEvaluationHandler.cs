using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.UserEvaluation.UserEvaluationsCommands.CompleteUserEvaluation;

public class CompleteUserEvaluationHandler : IRequestHandler<CompleteUserEvaluationCommand, ResultViewModel<UserEvaluationViewModel>>
{
    private readonly IUserEvaluationRepository _userEvaluationrepository;
    
    public CompleteUserEvaluationHandler(IUserEvaluationRepository userEvaluationRepository)
    {
        _userEvaluationrepository = userEvaluationRepository;
    }
    
    
    public async Task<ResultViewModel<UserEvaluationViewModel>> Handle(CompleteUserEvaluationCommand request, CancellationToken cancellationToken)
    {
        var existingEvaluation = await _userEvaluationrepository.GetByIdAsync(request.Id);

        if (existingEvaluation == null)
        {
            return ResultViewModel<UserEvaluationViewModel>.Error("Avaliação não encontrada");
        }
        
        existingEvaluation.Complete();
        await _userEvaluationrepository.SaveChangesAsync();

        return ResultViewModel<UserEvaluationViewModel>.Success(UserEvaluationViewModel.FromEntity(existingEvaluation));

    }
    
}