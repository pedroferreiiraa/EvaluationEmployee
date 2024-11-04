using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.LeaderAvaliation.LeaderAnswersCommands.InsertLeaderAnswer;

public class InsertLeaderAnswerHandler : IRequestHandler<InserLeaderAnswerCommand, ResultViewModel<int>>
{
    private readonly ILeaderAnswerRepository _leaderAnswerRepository;

    public InsertLeaderAnswerHandler(ILeaderAnswerRepository leaderAnswerRepository)
    {
        _leaderAnswerRepository = leaderAnswerRepository;
    }
    
    
    public async Task<ResultViewModel<int>> Handle(InserLeaderAnswerCommand request, CancellationToken cancellationToken)
    {
        var leaderAnswer = request.ToEntity();

        await _leaderAnswerRepository.AddAsync(leaderAnswer);
        await _leaderAnswerRepository.SaveChangesAsync();

        return ResultViewModel<int>.Success(leaderAnswer.Id);

    }
}