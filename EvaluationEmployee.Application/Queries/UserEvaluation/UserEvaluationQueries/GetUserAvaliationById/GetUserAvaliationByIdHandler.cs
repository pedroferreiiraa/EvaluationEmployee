using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.UserAvaliationQueries.GetUserAvaliationById
{
    public class GetUserAvaliationByIdHandler : IRequestHandler<GetUserAvaliationByIdQuery, ResultViewModel<UserEvaluationViewModel>>
    {
        private readonly IUserEvaluationRepository _repository;

        public GetUserAvaliationByIdHandler(IUserEvaluationRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<ResultViewModel<UserEvaluationViewModel>> Handle(GetUserAvaliationByIdQuery request, CancellationToken cancellationToken)
    {
        var avaliation = await _repository.GetByIdAsync(request.Id);

        if (avaliation == null)
        {
            return ResultViewModel<UserEvaluationViewModel>.Error("Avaliação não encontrada.");
        }

        var model = UserEvaluationViewModel.FromEntity(avaliation);

        return ResultViewModel<UserEvaluationViewModel>.Success(model);
    }
    }
}