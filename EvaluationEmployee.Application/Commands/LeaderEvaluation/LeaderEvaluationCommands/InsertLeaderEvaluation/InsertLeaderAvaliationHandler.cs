using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.LeaderAvaliation.LeaderAvaliationCommands.InsertLeaderAvaliation;

public class InsertLeaderAvaliationHandler : IRequestHandler<InsertLeaderAvaliationCommand, ResultViewModel<int>>
{
    private readonly ILeaderAvaliationRepository _leaderAvaliationRepository;
    private readonly ILeaderQuestionRepository _leaderQuestionRepository;

    public InsertLeaderAvaliationHandler(ILeaderAvaliationRepository leaderAvaliationRepository, ILeaderQuestionRepository leaderQuestionRepository)
    {
        _leaderAvaliationRepository = leaderAvaliationRepository;
        _leaderQuestionRepository = leaderQuestionRepository;
    }
    
    public async Task<ResultViewModel<int>> Handle(InsertLeaderAvaliationCommand request, CancellationToken cancellationToken)
    {
        // Validar se os QuestionIds são válidos
        var questionIds = request.LeaderAnswers.Select(a => a.QuestionId).ToList();
        var validQuestions = await _leaderQuestionRepository.GetQuestionsByIdsAsync(questionIds);
        if (validQuestions.Count != questionIds.Count)
        {
            return ResultViewModel<int>.Error("Uma ou mais perguntas são inválidas.");
        }

        var leaderAvaliation = request.ToEntity();

        await _leaderAvaliationRepository.AddAsync(leaderAvaliation);
        await _leaderAvaliationRepository.SaveChangesAsync();

        return ResultViewModel<int>.Success(leaderAvaliation.Id);
    }
}