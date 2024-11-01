using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using MediatR;

namespace _5W2H.Application.Commands.UserCommands.UpdateUser;

public class UpdateUserCommand : IRequest<ResultViewModel<int>>
{
    public int Id { get; set; }
    public string FullName { get;  set; }
    public string Role  { get;  set; }
    public string TypeMo { get; set; }
    public int DepartmentId { get; set; }
    
    
}