using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using MediatR;

namespace _5W2H.Application.Commands.DepartmentCommands.InsertDepartment;

public class InsertSetorCommand : IRequest<ResultViewModel<int>>
{
    public string Nome { get; set; }
    public int LiderId { get; set; }
    public int GestorId { get; set; }
    
    public Department ToEntity()
        => new (Nome, LiderId, GestorId);
}