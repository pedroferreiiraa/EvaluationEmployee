using _5W2H.Core.Entities;

namespace _5W2H.Application.Models;

public class LeaderAnswerViewModel
{
    public int AnswerId { get; set; }
    public int QuestionId { get; set; }
    public int AnswerNumber { get; set; }

    public static LeaderAnswerViewModel FromEntity(LeaderAnswer leaderAnswer)
    {
        return new LeaderAnswerViewModel
        {
            AnswerId = leaderAnswer.Id,
            QuestionId = leaderAnswer.QuestionId,
            AnswerNumber = leaderAnswer.AnswerNumber
        };
    }
    
}