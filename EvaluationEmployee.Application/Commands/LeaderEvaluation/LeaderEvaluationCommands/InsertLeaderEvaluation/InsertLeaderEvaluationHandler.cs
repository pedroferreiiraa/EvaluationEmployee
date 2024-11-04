using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.LeaderAvaliation.LeaderAvaliationCommands.InsertLeaderAvaliation;

public class InsertLeaderEvaluationHandler : IRequestHandler<InsertLeaderEvaluationCommand, ResultViewModel<int>>
{
    private readonly ILeaderEvaluationRepository _leaderEvaluationRepository;
    private readonly ILeaderQuestionRepository _leaderQuestionRepository;

    public InsertLeaderEvaluationHandler(ILeaderEvaluationRepository leaderEvaluationRepository, ILeaderQuestionRepository leaderQuestionRepository)
    {
        _leaderEvaluationRepository = leaderEvaluationRepository;
        _leaderQuestionRepository = leaderQuestionRepository;
    }
    
    public async Task<ResultViewModel<int>> Handle(InsertLeaderEvaluationCommand request, CancellationToken cancellationToken)
    {
        // Validar se os QuestionIds são válidos
        var questionIds = request.LeaderAnswers.Select(a => a.QuestionId).ToList();
        var validQuestions = await _leaderQuestionRepository.GetQuestionsByIdsAsync(questionIds);
        if (validQuestions.Count != questionIds.Count)
        {
            return ResultViewModel<int>.Error("Uma ou mais perguntas são inválidas.");
        }

        var leaderAvaliation = request.ToEntity();

        await _leaderEvaluationRepository.AddAsync(leaderAvaliation);
        await _leaderEvaluationRepository.SaveChangesAsync();

        return ResultViewModel<int>.Success(leaderAvaliation.Id);
    }
}