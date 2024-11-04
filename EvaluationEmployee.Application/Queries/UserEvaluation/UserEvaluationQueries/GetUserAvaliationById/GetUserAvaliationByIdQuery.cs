using _5W2H.Application.Models;
using MediatR;

namespace _5W2H.Application.Queries.UserAvaliationQueries.GetUserAvaliationById
{
    public class GetUserAvaliationByIdQuery : IRequest<ResultViewModel<UserEvaluationViewModel>>
    {
        public GetUserAvaliationByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}