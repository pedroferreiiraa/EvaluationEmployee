

using _5W2H.Core.Enums;

namespace _5W2H.Core.Entities;

public class LeaderEvaluation : BaseEntity
{
    public LeaderEvaluation(){}

    public LeaderEvaluation(int employeeId, int evaluationId, EvaluationStatusEnum status)
    {
        EmployeeId = employeeId;
        EvaluatorId = evaluationId;
        Status = status;

        LeaderAnswers = new List<LeaderAnswer>();
    }

    public int EmployeeId { get; private set; }
    public int EvaluatorId { get; private set; }

    public string DateReference { get; private set; }
    public EvaluationStatusEnum Status { get; private set; }
    public DateTime CompletedAt { get; private set; }
    public virtual ICollection<LeaderQuestion> LeaderQuestions { get; private set; }
    public virtual ICollection<LeaderAnswer> LeaderAnswers { get; private set; }

    public void AddAnswer(int questionId, int answerNumber)
    {
        // Verifique se já existe uma resposta para essa pergunta
        if (LeaderAnswers.Any(a => a.QuestionId == questionId))
        {
            throw new InvalidOperationException("A resposta para esta pergunta já foi adicionada.");
        }
        LeaderAnswers.Add(new LeaderAnswer(this.Id, questionId, answerNumber));
    }
    
    public void Complete()
    {
        if (Status == EvaluationStatusEnum.InProgress)
        {
            Status = EvaluationStatusEnum.Completed;
            CompletedAt = DateTime.Now;
        }
    }
}
