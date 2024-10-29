using _5W2H.Application.Models;
using MediatR;

namespace _5W2H.Application.Commands.UserCommands.DeleteUser;

public class DeleteUserCommand : IRequest<ResultViewModel<int>>
{
    public DeleteUserCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; } 
}