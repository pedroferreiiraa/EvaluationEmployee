using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using _5W2H.Infrastructure.Persistence.Migrations;
using MediatR;

namespace _5W2H.Application.Queries.LeaderAvaliation.LeaderAvaliationQueries.GetAllLeaderAvaliations;

public class GetAllLeaderEvaluationsHandler : IRequestHandler<GetAllLeaderEvaluationsQuery, List<LeaderEvaluationViewModel>>
{
    private readonly ILeaderEvaluationRepository _leaderEvaluationRepository;

    public GetAllLeaderEvaluationsHandler(ILeaderEvaluationRepository leaderEvaluationRepository)
    {
        _leaderEvaluationRepository = leaderEvaluationRepository;
    }

    
    
    public async Task<List<LeaderEvaluationViewModel>> Handle(GetAllLeaderEvaluationsQuery request, CancellationToken cancellationToken)
    {
        var leaderAvaliation = await _leaderEvaluationRepository.GetAllAsync();

        var leaderAvaliationViewModels = leaderAvaliation.Select(leaderAvaliation => new LeaderEvaluationViewModel
        {
            AvaliationId = leaderAvaliation.Id,
            EmployeeId = leaderAvaliation.EmployeeId,
            EvaluatorId = leaderAvaliation.EvaluatorId,
            DateReference = leaderAvaliation.DateReference,
            Status = leaderAvaliation.Status,
            CompletedAt = leaderAvaliation.CompletedAt,
            LeaderQuestions = leaderAvaliation.LeaderQuestions.Select(q => new LeaderQuestionViewModel
            {
                QuestionId = q.Id,
                Text = q.Text,
                Topic = q.Topic,
            }).ToList(),
            LeaderAnswers = leaderAvaliation.LeaderAnswers.Select(a => new LeaderAnswerViewModel
            {
                AnswerId = a.Id,
                QuestionId = a.QuestionId,
                AnswerNumber = a.AnswerNumber
            }).ToList()
        }).ToList();
        
        return leaderAvaliationViewModels;
    }
}