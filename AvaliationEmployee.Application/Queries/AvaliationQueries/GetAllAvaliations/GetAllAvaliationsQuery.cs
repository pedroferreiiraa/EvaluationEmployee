using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using MediatR;

namespace _5W2H.Application.Queries.ProjectQueries.GetAllProjects;

public class GetAllAvaliationsQuery : IRequest<ResultViewModel<PaginatedList<AvaliacaoViewModel>>>
{
    public string Search { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    
    public int Status { get; set; } = -1;

    public GetAllAvaliationsQuery(string search, int pageNumber, int pageSize, int status)
    {
        Search = search;
        PageNumber = pageNumber;
        PageSize = pageSize;
        Status = status;
    }
}
