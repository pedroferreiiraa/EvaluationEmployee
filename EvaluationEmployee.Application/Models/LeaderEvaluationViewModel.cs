
using _5W2H.Application.Queries.LeaderAvaliation.LeaderAvaliationQueries.GetAllLeaderAvaliations;
using _5W2H.Core.Entities;
using _5W2H.Core.Enums;

namespace _5W2H.Application.Models
{
    public class LeaderEvaluationViewModel
    {
        
        public int AvaliationId { get; set; }
        public int EmployeeId { get; set; }
        public int EvaluatorId { get; set; } 
        public string DateReference { get; set; }
        public string? ImprovePoints { get;  set;}
        public string? Pdi { get;  set; }
        public string? Goals { get;  set; }
        public string? SixMonthAlignment { get;  set; }
        public EvaluationStatusEnum Status { get; set; }
        
        public DateTime CompletedAt { get; set; }

        public List<LeaderQuestionViewModel> LeaderQuestions { get; set; } = new();
        public List<LeaderAnswerViewModel> LeaderAnswers { get; set; } = new();
        
        public List<TopicLeaderAverageViewModel> TopicAverages { get; set; }

        public static LeaderEvaluationViewModel FromEntity(LeaderEvaluation leaderEvaluation)
        {
            var topicAverages = leaderEvaluation.LeaderAnswers
                .Where(a => a.LeaderQuestion != null) // Verifica se a pergunta não é nula
                .GroupBy(a => a.LeaderQuestion.Topic)  // Agrupa pelo tópico
                .Select(g => new TopicLeaderAverageViewModel
                {
                    Topic = g.Key,
                    Average = g.Average(a => a.AnswerNumber) // Calcula a média das respostas
                })
                .ToList();
            
            return new LeaderEvaluationViewModel
            {
                AvaliationId = leaderEvaluation.Id,
                EmployeeId = leaderEvaluation.EmployeeId,
                EvaluatorId = leaderEvaluation.EvaluatorId,
                DateReference = leaderEvaluation.DateReference,
                ImprovePoints = leaderEvaluation.ImprovePoints,
                Pdi = leaderEvaluation.Pdi,
                Goals = leaderEvaluation.Goals,
                SixMonthAlignment = leaderEvaluation.SixMonthAlignment,
                Status = leaderEvaluation.Status,
                CompletedAt = leaderEvaluation.CompletedAt,
                LeaderAnswers = leaderEvaluation.LeaderAnswers.Select(a => LeaderAnswerViewModel.FromEntity(a)).ToList(),
                TopicAverages = topicAverages
            };
        }
    }
    
    
}