using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.LeaderAvaliation.LeaderQuestionCommands.InsertLeaderQuestion;

public class InsertLeaderQuestionHandler : IRequestHandler<InsertLeaderQuestionCommand, ResultViewModel<int>>
{
    private readonly ILeaderQuestionRepository _leaderQuestionRepository;

    public InsertLeaderQuestionHandler(ILeaderQuestionRepository leaderQuestionRepository)
    {
        _leaderQuestionRepository = leaderQuestionRepository;
    }
    
    public async Task<ResultViewModel<int>> Handle(InsertLeaderQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = request.ToEntity();
        
        await _leaderQuestionRepository.AddAsync(question);
        return ResultViewModel<int>.Success(question.Id);
    }
}