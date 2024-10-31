using _5W2H.Core.Enums;

namespace _5W2H.Core.Entities;

public class Avaliation : BaseEntity
{
    public Avaliation(int employeeId)
    {
        EmployeeId = employeeId;

        Answers = new List<Answer>();
    }

    public int EmployeeId { get; private set; }
    
    public virtual ICollection<Question> Questions { get; private set; }
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
