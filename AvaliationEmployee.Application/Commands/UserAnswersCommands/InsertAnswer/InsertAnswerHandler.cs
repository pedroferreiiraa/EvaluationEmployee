using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.UserAnswersCommands.InsertAnswer;

public class InsertAnswerHandler : IRequestHandler<InsertAnswerCommand, ResultViewModel<int>>
{
    private readonly IUserAnswerRepository _userAnswerRepository;
    

    public InsertAnswerHandler(IUserAnswerRepository userAnswerRepository)
    {
        _userAnswerRepository = userAnswerRepository;
    }
    
    public async Task<ResultViewModel<int>> Handle(InsertAnswerCommand request, CancellationToken cancellationToken)
    {
        var answer = request.ToEntity();
        
        await _userAnswerRepository.AddAsync(answer);
        await _userAnswerRepository.SaveChangesAsync();
        
        return ResultViewModel<int>.Success(answer.Id);
        
    }
}