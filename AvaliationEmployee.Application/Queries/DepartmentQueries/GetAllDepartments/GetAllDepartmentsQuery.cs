using _5W2H.Application.Models;
using MediatR;

namespace _5W2H.Application.Queries.DepartmentQueries.GetAllDepartments;

public class GetAllDepartmentsQuery : IRequest<ResultViewModel<List<SetorViewModel>>>
{
    
}