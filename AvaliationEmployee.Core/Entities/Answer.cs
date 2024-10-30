namespace _5W2H.Core.Entities;

public class Answer : BaseEntity
{
    public Answer() {}
    public Answer(int avaliationId,  int questionId,  int answerNumber)
    {
        AvaliationId = avaliationId;
        QuestionId = questionId;
        AnswerNumber = answerNumber;
    }

    public int AvaliationId { get; set; }
    public Avaliation Avaliation { get; set; }
    public int QuestionId { get; set; }
    public Question Question { get; set; }
    public int AnswerNumber { get; set; } 
}