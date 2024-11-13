using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.UserAvaliationQueries.GetAllUsersAvaliations
{
    
    public class TopicAverageViewModel
    {
        public string Topic { get; set; } // Nome do tópico
        public double Average { get; set; } // Média das respostas
    }

    public class GetAllEvaluationsHandler : IRequestHandler<GetAllEvaluationsQuery, List<UserEvaluationViewModel>>
    {
        private readonly IUserEvaluationRepository _userEvaluationRepository;

        public GetAllEvaluationsHandler(IUserEvaluationRepository userEvaluationRepository)
        {
            _userEvaluationRepository = userEvaluationRepository;
        }

        public async Task<List<UserEvaluationViewModel>> Handle(GetAllEvaluationsQuery request,
            CancellationToken cancellationToken)
        {
            var evaluations = await _userEvaluationRepository.GetAllAsync();

            var evaluationViewModels = evaluations.Select(evaluation =>
            {
                var topicAverages = evaluation.Answers
                    .Where(a => a.UserQuestion != null) // Verifica se a UserQuestion não é nula
                    .GroupBy(a => a.UserQuestion.Topic) // Usa a propriedade correta
                    .Select(g => new TopicAverageViewModel
                    {
                        Topic = g.Key,
                        Average = g.Average(a => a.AnswerNumber)
                    })
                    .ToList();

                return new UserEvaluationViewModel
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
                    Answers = evaluation.Answers.Select(a => new AnswerViewModel
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
}