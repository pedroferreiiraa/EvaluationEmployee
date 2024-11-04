
using _5W2H.Core.Entities;
using _5W2H.Core.Enums;

namespace _5W2H.Application.Models
{
    public class UserEvaluationViewModel
    {
        
        public int AvaliationId { get; set; }
        public int EmployeeId { get; set; }
        public int EvaluatorId { get; set; }
        
        public EvaluationStatusEnum Status { get; set; }
        public DateTime? CompletedAt { get; set; }
        public List<QuestionViewModel> Questions { get; set; } = new();
        public List<AnswerViewModel> Answers { get; set; } = new();

        public static UserEvaluationViewModel FromEntity(UserAvaliation userAvaliation)
        {
            return new UserEvaluationViewModel
            {
                AvaliationId = userAvaliation.Id,
                EmployeeId = userAvaliation.EmployeeId,
                EvaluatorId = userAvaliation.EvaluatorId,
                Status = userAvaliation.Status,
                CompletedAt = userAvaliation.CompletedAt,
                Questions = userAvaliation.Questions.Select(q => QuestionViewModel.FromEntity(q)).ToList(),
                Answers = userAvaliation.Answers.Select(a => AnswerViewModel.FromEntity(a)).ToList()
            };
        }
    }
    
    
}