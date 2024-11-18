using _5W2H.Application.Models;
using MediatR;

namespace _5W2H.Application.Queries.UserEvaluation.UserEvaluationQueries.GetOthersEvaluations;

public class GetEvaluationsByOthersQuery : IRequest<ResultViewModel<List<UserEvaluationViewModel>>>
{
    public int EmployeeId { get; }

    public GetEvaluationsByOthersQuery(int employeeId)
    {
        EmployeeId = employeeId;
    }
    
}