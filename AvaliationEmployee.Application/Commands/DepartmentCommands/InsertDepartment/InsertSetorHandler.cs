using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.DepartmentCommands.InsertDepartment;

public class InsertSetorHandler : IRequestHandler<InsertSetorCommand, ResultViewModel<int>>
{
    private readonly IDepartmentRepository _repository;

    public InsertSetorHandler(IDepartmentRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<ResultViewModel<int>> Handle(InsertSetorCommand request, CancellationToken cancellationToken)
    {
        var departament = request.ToEntity();

        await _repository.AddAsync(departament);
        
        return ResultViewModel<int>.Success(departament.Id);
    }
}