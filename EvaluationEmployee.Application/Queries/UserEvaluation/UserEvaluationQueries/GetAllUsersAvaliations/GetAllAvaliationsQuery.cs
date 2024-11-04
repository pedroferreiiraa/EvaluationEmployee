using _5W2H.Application.Models;
using MediatR;

namespace _5W2H.Application.Queries.UserAvaliationQueries.GetAllUsersAvaliations
{
    public class GetAllAvaliationsQuery : IRequest<List<UserEvaluationViewModel>>
    {
    }
}