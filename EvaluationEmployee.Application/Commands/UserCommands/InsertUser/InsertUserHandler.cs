using _5W2H.Core.Repositories;
using _5W2H.Core.Services;
using MediatR;

namespace _5W2H.Application.Commands.UserCommands.InsertUser;


public class InsertUserHandler : IRequestHandler<InsertUserCommand, int>
{
    
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public InsertUserHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }
    
    public async Task<int> Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {
        
        var user = request.ToEntity(request.Password);
        
        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        return user.Id;

    }
}