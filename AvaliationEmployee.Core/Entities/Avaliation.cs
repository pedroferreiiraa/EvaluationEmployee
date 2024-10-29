using _5W2H.Core.Enums;

namespace _5W2H.Core.Entities;

public class Avaliation : BaseEntity
{
   
    public Avaliation(int colaboradorId, int avaliadorId, AvaliationStatusEnum status, ICollection<Answer> answers, ICollection<Question> questions)
    {
        ColaboradorId = colaboradorId;
        AvaliadorId = avaliadorId;
        Status = status;
        Answers = answers ?? new List<Answer>(); 
        Questions = questions ?? new List<Question>(); 
    }
    

    public int ColaboradorId { get; private set; } 
    public int AvaliadorId { get; private set; }
    public User User { get; private set; }
    public User Avaliador { get; private set; }
    public DateTime CompletedAt { get; private set; }
    public DateTime StartedAt { get; private set; }
    public virtual ICollection<Question> Questions { get; set; } // Perguntas da avaliação
    public virtual ICollection<Answer> Answers { get; set; } // Respostas da avaliação
    public AvaliationStatusEnum Status { get; private set;}


    public void Start()
    {
        if (Status == AvaliationStatusEnum.Created)
        {
            Status = AvaliationStatusEnum.InProgress;
            StartedAt = DateTime.Now;
        }
    }
    
    public void Complete()
    {
        if (Status == AvaliationStatusEnum.InProgress)
        {
            Status = AvaliationStatusEnum.Completed;
            CompletedAt = DateTime.Now;
        }
    }
    
}