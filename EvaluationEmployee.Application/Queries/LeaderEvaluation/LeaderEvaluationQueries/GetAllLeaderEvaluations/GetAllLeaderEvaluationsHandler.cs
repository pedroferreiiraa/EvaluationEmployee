using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using _5W2H.Infrastructure.Persistence.Migrations;
using MediatR;

namespace _5W2H.Application.Queries.LeaderAvaliation.LeaderAvaliationQueries.GetAllLeaderAvaliations;


public class TopicLeaderAverageViewModel
{
    public string Topic { get; set; } // Nome do tópico
    public double Average { get; set; } // Média das respostas
}


public class GetAllLeaderEvaluationsHandler : IRequestHandler<GetAllLeaderEvaluationsQuery, List<LeaderEvaluationViewModel>>
{
    private readonly ILeaderEvaluationRepository _leaderEvaluationRepository;

    public GetAllLeaderEvaluationsHandler(ILeaderEvaluationRepository leaderEvaluationRepository)
    {
        _leaderEvaluationRepository = leaderEvaluationRepository;
    }

    
    public async Task<List<LeaderEvaluationViewModel>> Handle(GetAllLeaderEvaluationsQuery request,
        CancellationToken cancellationToken)
    {
        var evaluations = await _leaderEvaluationRepository.GetAllAsync();

        var evaluationViewModels = evaluations.Select(evaluation =>
        {
            var topicAverages = evaluation.LeaderAnswers
                .Where(a => a.LeaderQuestion != null) // Verifica se a UserQuestion não é nula
                .GroupBy(a => a.LeaderQuestion.Topic) // Usa a propriedade correta
                .Select(g => new TopicLeaderAverageViewModel
                {
                    Topic = g.Key,
                    Average = g.Average(a => a.AnswerNumber)
                })
                .ToList();

            return new LeaderEvaluationViewModel
            {
                AvaliationId = evaluation.Id,
                EmployeeId = evaluation.EmployeeId,
                EvaluatorId = evaluation.EvaluatorId,
                DateReference = evaluation.DateReference,
                ImprovePoints = evaluation.ImprovePoints,
                Pdi = evaluation.Pdi,
                Goals = evaluation.Goals,
                SixMonthAlignment = evaluation.SixMonthAlignment,
                Status = evaluation.Status,
                CompletedAt = evaluation.CompletedAt,
                LeaderAnswers = evaluation.LeaderAnswers.Select(a => new LeaderAnswerViewModel
                {
                    AnswerId = a.Id,
                    QuestionId = a.QuestionId,
                    AnswerNumber = a.AnswerNumber
                }).ToList(),
                TopicAverages = topicAverages
            };
        }).ToList();

        return evaluationViewModels;
    }
}
