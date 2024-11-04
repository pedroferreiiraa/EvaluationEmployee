using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.UserQuestionCommands.InsertQuestion;

public class InsertQuestionHandler : IRequestHandler<InsertQuestionCommand, ResultViewModel<int>>
{
    private readonly IUserQuestionRepository _userQuestionRepository;

    public InsertQuestionHandler(IUserQuestionRepository userQuestionRepository)
    {
        _userQuestionRepository = userQuestionRepository;
    }
    
    public async Task<ResultViewModel<int>> Handle(InsertQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = request.ToEntity();
        
        await _userQuestionRepository.AddAsync(question);
        return ResultViewModel<int>.Success(question.Id);
    }
}