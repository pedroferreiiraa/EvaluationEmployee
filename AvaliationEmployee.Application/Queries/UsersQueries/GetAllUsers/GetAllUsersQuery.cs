using _5W2H.Application.Models;
using MediatR;

namespace _5W2H.Application.Queries.UsersQueries.GetAllUsers;

public class GetAllUsersQuery : IRequest<ResultViewModel<List<ColaboradorViewModel>>>
{
   
}