

using _5W2H.Core.Enums;

namespace _5W2H.Core.Entities;

public class UserEvaluation : BaseEntity
{
    public UserEvaluation(){}

    public UserEvaluation(int employeeId, int evaluationId, EvaluationStatusEnum status, string reference)
    {
        EmployeeId = employeeId;
        EvaluatorId = evaluationId;
        Status = status;
        DateReference = reference;

        Answers = new List<Answer>();
    }

    public int EmployeeId { get; private set; }
    public int EvaluatorId { get; private set; }
    
    public string DateReference { get; private set; }
    
    public EvaluationStatusEnum Status { get; private set; }
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
    public void Complete()
    {
        if (Status == EvaluationStatusEnum.Created)
        {
            Status = EvaluationStatusEnum.Completed;
            CompletedAt = DateTime.Now;
        }
    }
    
}
