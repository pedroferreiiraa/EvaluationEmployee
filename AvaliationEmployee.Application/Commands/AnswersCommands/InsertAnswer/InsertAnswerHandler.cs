using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.AnswersCommands.InsertAnswer;

public class InsertAnswerHandler : IRequestHandler<InsertAnswerCommand, ResultViewModel<int>>
{
    private readonly IAnswerRepository _answerRepository;
    

    public InsertAnswerHandler(IAnswerRepository answerRepository)
    {
        _answerRepository = answerRepository;
    }
    
    public async Task<ResultViewModel<int>> Handle(InsertAnswerCommand request, CancellationToken cancellationToken)
    {
        var answer = request.ToEntity();
        
        await _answerRepository.AddAsync(answer);
        await _answerRepository.SaveChangesAsync();
        
        return ResultViewModel<int>.Success(answer.Id);
        
    }
}