namespace _5W2H.Core.Entities;

public class Answer : BaseEntity
{
    public Answer(int avaliacaoId, Avaliation avaliation, int perguntaId, Question question, int responseNumber)
    {
        AvaliationId = avaliacaoId;
        Avaliation = avaliation;
        QuestionId = perguntaId;
        Question = question;
        ResponseNumber = responseNumber;
    }

    public int AvaliationId { get; set; }
    public Avaliation Avaliation { get; set; }
    public int QuestionId { get; set; }
    public Question Question { get; set; }
    public int ResponseNumber { get; set; } 
}