using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.UserEvaluation.UserEvaluationQueries.GetSelfEvaluation;

public class GetSelfEvaluationHandler : IRequestHandler<GetSelfEvaluationQuery, ResultViewModel<List<UserEvaluationViewModel>>>
{
    private readonly IUserEvaluationRepository _repository;

    public GetSelfEvaluationHandler(IUserEvaluationRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<List<UserEvaluationViewModel>>> Handle(GetSelfEvaluationQuery query, CancellationToken cancellationToken)
    {
        if (query == null) throw new ArgumentNullException(nameof(query));

        // Busca as avaliações do repositório
        var evaluations = await _repository.GetEvaluationsByUserIdAsync(query.UserId);

        // Verifica se há resultados
        if (evaluations == null || !evaluations.Any())
        {
            return ResultViewModel<List<UserEvaluationViewModel>>.Error("Nenhuma avaliação foi encontrada. ");
        }

        // Converte para ViewModel
        var evaluationViewModels = evaluations
            .Select(UserEvaluationViewModel.FromEntity)
            .ToList();

        return ResultViewModel<List<UserEvaluationViewModel>>.Success(evaluationViewModels);
    }
}