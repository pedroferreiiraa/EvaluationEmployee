using _5W2H.Core.Entities;

namespace _5W2H.Application.Models;

public class AnswerViewModel
{
    public int AnswerId { get; set; }
    public int QuestionId { get; set; }
    public int AnswerNumber { get; set; }

    public static AnswerViewModel FromEntity(Answer answer)
    {
        return new AnswerViewModel
        {
            AnswerId = answer.Id,
            QuestionId = answer.QuestionId,
            AnswerNumber = answer.AnswerNumber
        };
    }
    
}