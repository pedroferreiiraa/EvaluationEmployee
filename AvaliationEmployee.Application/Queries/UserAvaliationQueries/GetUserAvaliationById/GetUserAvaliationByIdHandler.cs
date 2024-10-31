using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.UserAvaliationQueries.GetUserAvaliationById
{
    public class GetUserAvaliationByIdHandler : IRequestHandler<GetUserAvaliationByIdQuery, ResultViewModel<UserAvaliationViewModel>>
    {
        private readonly IUserAvaliationRepository _repository;

        public GetUserAvaliationByIdHandler(IUserAvaliationRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<ResultViewModel<UserAvaliationViewModel>> Handle(GetUserAvaliationByIdQuery request, CancellationToken cancellationToken)
        {
            var avaliation = await _repository.GetByIdAsync(request.Id);

            if (avaliation == null)
            {
                return null;
            }

            var model = UserAvaliationViewModel.FromEntity(avaliation);

            return ResultViewModel<UserAvaliationViewModel>.Success(model);
        }
    }
}