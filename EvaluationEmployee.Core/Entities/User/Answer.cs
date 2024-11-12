namespace _5W2H.Core.Entities;

public class Answer : BaseEntity
{
    public Answer(int avaliationId, int questionId, int answerNumber)
    {
        AvaliationId = avaliationId;
        QuestionId = questionId;
        AnswerNumber = answerNumber;
    }

    public int AvaliationId { get; private set; }
    public UserEvaluation UserEvaluation { get; private set; }
    public int QuestionId { get; private set; }
    public UserQuestion UserQuestion { get; private set; }
    public int AnswerNumber { get; private set; }
}
