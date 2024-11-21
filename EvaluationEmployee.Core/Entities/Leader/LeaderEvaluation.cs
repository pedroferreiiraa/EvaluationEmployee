

using _5W2H.Core.Enums;

namespace _5W2H.Core.Entities;

public class LeaderEvaluation : BaseEntity
{
    public LeaderEvaluation(){}

    public LeaderEvaluation(int leaderId, int evaluatorId, EvaluationStatusEnum status, string reference, string improvePoints, string pdi, string goals, string sixMonthAlignment)
    {
        LeaderId = leaderId;
        EvaluatorId = evaluatorId;
        Status = status;
        DateReference = reference;
        ImprovePoints = improvePoints;
        Pdi = pdi;
        Goals = goals;
        SixMonthAlignment = sixMonthAlignment;

        LeaderAnswers = new List<LeaderAnswer>();
    }

    public int LeaderId { get; private set; }
    public int EvaluatorId { get; private set; }
    public string DateReference { get; private set; }
    
    public string? ImprovePoints { get; private set;}
    public string? Pdi { get; private set; }
    public string? Goals { get; private set; }
    public string? SixMonthAlignment { get; private set; }
    public EvaluationStatusEnum Status { get; private set; }
    public DateTime CompletedAt { get; private set; }
    public virtual ICollection<LeaderQuestion> LeaderQuestions { get; private set; }
    public virtual ICollection<LeaderAnswer> LeaderAnswers { get; private set; }

    public void AddAnswer(int questionId, int answerNumber)
    {
        if (LeaderAnswers.Any(a => a.QuestionId == questionId))
        {
            throw new InvalidOperationException("A resposta para esta pergunta já foi adicionada.");
        }
        LeaderAnswers.Add(new LeaderAnswer(Id, questionId, answerNumber));
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
