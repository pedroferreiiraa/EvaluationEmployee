using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.UserAnwersQueries.GetAllUsersAnswers;

public class GetAllAnswersHandler : IRequestHandler<GetAllAnswersQuery, List<AnswerViewModel>>
{
    private readonly IUserAnswerRepository _userAnswerRepository;

    public GetAllAnswersHandler(IUserAnswerRepository userAnswerRepository)
    {
        _userAnswerRepository = userAnswerRepository;
    }
    
    public async Task<List<AnswerViewModel>> Handle(GetAllAnswersQuery request, CancellationToken cancellationToken)
    {
        var anwers = await _userAnswerRepository.GetAllAsync();

        return new List<AnswerViewModel>();
    }
}