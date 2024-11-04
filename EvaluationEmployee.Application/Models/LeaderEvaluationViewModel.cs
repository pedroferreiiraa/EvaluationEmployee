
using _5W2H.Core.Entities;
using _5W2H.Core.Enums;

namespace _5W2H.Application.Models
{
    public class LeaderEvaluationViewModel
    {
        
        public int AvaliationId { get; set; }
        public int EmployeeId { get; set; }
        public int EvaluatorId { get; set; } 

        public EvaluationStatusEnum Status { get; set; }
        
        public DateTime? CompletedAt { get; set; }

        public List<LeaderQuestionViewModel> LeaderQuestions { get; set; } = new();
        public List<LeaderAnswerViewModel> LeaderAnswers { get; set; } = new();

        public static LeaderEvaluationViewModel FromEntity(LeaderAvaliation leaderAvaliation)
        {
            return new LeaderEvaluationViewModel
            {
                AvaliationId = leaderAvaliation.Id,
                EmployeeId = leaderAvaliation.EmployeeId,
                EvaluatorId = leaderAvaliation.EvaluatorId,
                Status = leaderAvaliation.Status,
                CompletedAt = leaderAvaliation.CompletedAt,
                LeaderQuestions = leaderAvaliation.LeaderQuestions.Select(q => LeaderQuestionViewModel.FromEntity(q)).ToList(),
                LeaderAnswers = leaderAvaliation.LeaderAnswers.Select(a => LeaderAnswerViewModel.FromEntity(a)).ToList()
            };
        }
    }
    
    
}