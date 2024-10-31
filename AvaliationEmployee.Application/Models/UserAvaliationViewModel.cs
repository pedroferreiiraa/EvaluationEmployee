
using _5W2H.Core.Entities;

namespace _5W2H.Application.Models
{
    public class UserAvaliationViewModel
    {
        
        public int AvaliationId { get; set; }
        public int EmployeeId { get; set; }
        public int EvaluatorId { get; set; } // Avaliador
        public DateTime StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        public List<QuestionViewModel> Questions { get; set; } = new();
        public List<AnswerViewModel> Answers { get; set; } = new();
    }
    
    
}