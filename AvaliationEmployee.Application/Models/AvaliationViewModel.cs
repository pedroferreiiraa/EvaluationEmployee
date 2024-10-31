using _5W2H.Core.Entities;
using _5W2H.Core.Enums;

namespace _5W2H.Application.Models
{
    public class AvaliationViewModel
    {
      public int AvaliationId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }

    public List<QuestionViewModel> Questions { get; set; } = new();
    public List<AnswerViewModel> Answers { get; set; } = new();
    }
}