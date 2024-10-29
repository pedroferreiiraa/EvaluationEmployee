using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.UsersQueries.GetUserById;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ColaboradorViewModel>
{
    private readonly IUserRepository _userRepository;
    public GetUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    
    public async Task<ColaboradorViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        if (user == null)
        {
            return null;
        }

        return new ColaboradorViewModel(user);
    }
}