using _5W2H.Application.Models;
using MediatR;

namespace _5W2H.Application.Queries.UserAvaliationQueries.GetUserAvaliationById
{
    public class GetUserEvaluationByIdQuery : IRequest<ResultViewModel<UserEvaluationViewModel>>
    {
        public GetUserEvaluationByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}