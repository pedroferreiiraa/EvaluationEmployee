namespace _5W2H.Core.Entities;

public class LeaderAnswer : BaseEntity
{
    public LeaderAnswer(int avaliationId, int questionId, int answerNumber)
    {
        AvaliationId = avaliationId;
        QuestionId = questionId;
        AnswerNumber = answerNumber;
    }

    public int AvaliationId { get; private set; }
    public LeaderAvaliation LeaderAvaliation { get; private set; }
    public int QuestionId { get; private set; }
    public LeaderQuestion LeaderQuestion { get; private set; }
    public int AnswerNumber { get; private set; }
}
