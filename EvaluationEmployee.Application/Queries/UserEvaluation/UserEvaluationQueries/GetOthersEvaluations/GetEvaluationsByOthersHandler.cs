using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.UserEvaluation.UserEvaluationQueries.GetOthersEvaluations;

public class GetEvaluationsByOthersQueryHandler : IRequestHandler<GetEvaluationsByOthersQuery, ResultViewModel<List<UserEvaluationViewModel>>>
{
    private readonly IUserEvaluationRepository _repository;

    public GetEvaluationsByOthersQueryHandler(IUserEvaluationRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<List<UserEvaluationViewModel>>> Handle(GetEvaluationsByOthersQuery request, CancellationToken cancellationToken)
    {
        // Obtém as avaliações feitas por outros para o colaborador
        var evaluations = await _repository.GetEvaluationsByOthers(request.EmployeeId);

        // Mapeia as avaliações para o modelo de visualização (ViewModel)
        var evaluationViewModels = evaluations
            .Select(UserEvaluationViewModel.FromEntity)  // Converte cada UserEvaluation em UserEvaluationViewModel
            .ToList();

        // Retorna o resultado encapsulado em ResultViewModel
        return new ResultViewModel<List<UserEvaluationViewModel>>(evaluationViewModels);
    }
}
