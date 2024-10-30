using _5W2H.Core.Enums;

namespace _5W2H.Core.Entities;

public class Avaliation : BaseEntity
{
    public Avaliation() {}
    public Avaliation(int colaboradorId, int avaliadorId, ICollection<Answer> answers, ICollection<Question> questions)
    {
        EmployeeId = colaboradorId;
        AvaliadorId = avaliadorId;
        
        Answers = answers ?? new List<Answer>(); 
        Questions = questions ?? new List<Question>(); 
    }
    

    public int EmployeeId { get; private set; } 
    public int AvaliadorId { get; private set; }
    public User User { get; private set; }
    public User Avaliador { get; private set; }
    public DateTime CompletedAt { get; private set; }
    public DateTime StartedAt { get; private set; }
    public virtual ICollection<Question> Questions { get; set; } // Perguntas da avaliação
    public virtual ICollection<Answer> Answers { get; set; } // Respostas da avaliação
   


   
    
}