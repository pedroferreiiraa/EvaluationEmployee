
using _5W2H.Application.Models;
using MediatR;

namespace _5W2H.Application.Queries.AvaliationQueries.GetAllAvaliations
{
    public class GetAllAvaliationsQuery : IRequest<List<AvaliationViewModel>>
    {
    }
}