

namespace _5W2H.Core.Entities;

public class UserAvaliation : BaseEntity
{
    public UserAvaliation(){}

    public UserAvaliation(int employeeId, int evaluationId)
    {
        EmployeeId = employeeId;
        EvaluatorId = evaluationId;

        Answers = new List<Answer>();
    }

    public int EmployeeId { get; private set; }
    public int EvaluatorId { get; private set; }
    public DateTime StartedAt { get; private set; }
    public DateTime CompletedAt { get; private set; }
    public virtual ICollection<UserQuestion> Questions { get; private set; }
    public virtual ICollection<Answer> Answers { get; private set; }

    public void AddAnswer(int questionId, int answerNumber)
    {
        // Verifique se já existe uma resposta para essa pergunta
        if (Answers.Any(a => a.QuestionId == questionId))
        {
            throw new InvalidOperationException("A resposta para esta pergunta já foi adicionada.");
        }
        Answers.Add(new Answer(this.Id, questionId, answerNumber));
    }
}
