using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.QuestionCommands.InsertQuestion;

public class InsertQuestionHandler : IRequestHandler<InsertQuestionCommand, ResultViewModel<int>>
{
    private readonly IQuestionRepository _questionRepository;

    public InsertQuestionHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }
    
    public async Task<ResultViewModel<int>> Handle(InsertQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = request.ToEntity();
        
        await _questionRepository.AddAsync(question);
        return ResultViewModel<int>.Success(question.Id);
    }
}