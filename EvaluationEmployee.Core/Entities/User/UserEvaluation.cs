

using _5W2H.Core.Enums;

namespace _5W2H.Core.Entities;

public class UserEvaluation : BaseEntity
{
    public UserEvaluation(){}

    public UserEvaluation(int employeeId, int evaluatorId, EvaluationStatusEnum status, string reference, string improvePoints, string pdi, string goals, string sixMonthAlignment)
    {
        EmployeeId = employeeId;
        EvaluatorId = evaluatorId;
        Status = status;
        DateReference = reference;
        ImprovePoints = improvePoints;
        Pdi = pdi;
        Goals = goals;
        SixMonthAlignment = sixMonthAlignment;

        Answers = new List<Answer>();
    }
    public int EmployeeId { get; private set; }
    public int EvaluatorId { get; private set; }
    public string DateReference { get; private set; }
    public string? ImprovePoints { get; private set;}
    public string? Pdi { get; private set; }
    public string? Goals { get; private set; }
    public string? SixMonthAlignment { get; private set; }
    public EvaluationStatusEnum Status { get; private set; }
    public DateTime CompletedAt { get; private set; }
    public virtual ICollection<UserQuestion> Questions { get; private set; }
    public virtual ICollection<Answer> Answers { get; private set; }

    public void AddAnswer(int questionId, int answerNumber)
    {
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
