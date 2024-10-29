namespace _5W2H.Core.Entities;

public class Question : BaseEntity
{
    public Question() { }
    
    public Question(string text)
    {
        Text = text;
    }

    public string Text { get; set; } // Texto da pergunta
    public virtual ICollection<Avaliation> Avaliations { get; set; } // Avaliações onde esta pergunta aparece
}