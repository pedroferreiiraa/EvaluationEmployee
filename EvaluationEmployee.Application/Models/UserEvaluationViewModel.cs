
using _5W2H.Core.Entities;
using _5W2H.Core.Enums;

namespace _5W2H.Application.Models
{
    public class UserEvaluationViewModel
    {
        
        public int AvaliationId { get; set; }
        public int EvaluatorId { get; set; }
        public int EmployeeId { get; set; }
        public string DateReference { get; set; }
        public EvaluationStatusEnum Status { get; set; }
        public DateTime CompletedAt { get; set; }
        public List<QuestionViewModel> Questions { get; set; } = new();
        public List<AnswerViewModel> Answers { get; set; } = new();

        public static UserEvaluationViewModel FromEntity(UserEvaluation userEvaluation)
        {
            return new UserEvaluationViewModel
            {
                AvaliationId = userEvaluation.Id,
                EmployeeId = userEvaluation.EmployeeId,
           
                EvaluatorId = userEvaluation.EvaluatorId,
                DateReference = userEvaluation.DateReference,
                Status = userEvaluation.Status,
                CompletedAt = userEvaluation.CompletedAt,
                Questions = userEvaluation.Questions.Select(q => QuestionViewModel.FromEntity(q)).ToList(),
                Answers = userEvaluation.Answers.Select(a => AnswerViewModel.FromEntity(a)).ToList()
            };
        }
    }
    
    
}