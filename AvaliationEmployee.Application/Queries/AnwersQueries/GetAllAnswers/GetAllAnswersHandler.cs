using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.AnwersQueries.GetAllAnswers;

public class GetAllAnswersHandler : IRequestHandler<GetAllAnswersQuery, List<AnswerViewModel>>
{
    private readonly IAnswerRepository _answerRepository;

    public GetAllAnswersHandler(IAnswerRepository answerRepository)
    {
        _answerRepository = answerRepository;
    }
    
    public async Task<List<AnswerViewModel>> Handle(GetAllAnswersQuery request, CancellationToken cancellationToken)
    {
        var anwers = await _answerRepository.GetAllAsync();

        return new List<AnswerViewModel>();
    }
}