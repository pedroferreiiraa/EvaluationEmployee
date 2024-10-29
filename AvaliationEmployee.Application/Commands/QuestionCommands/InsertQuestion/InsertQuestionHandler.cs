using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.QuestionCommands.InsertQuestion;

public class InsertQuestionHandler : IRequestHandler<InsertQuestionCommand, int>
{
    private readonly IQuestionRepository _questionRepository;

    public InsertQuestionHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }
    
    public async Task<int> Handle(InsertQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = request.ToEntity(request.Text);
        
        await _questionRepository.AddAsync(question);
        return question.Id;
    }
}