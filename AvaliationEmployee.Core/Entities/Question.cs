namespace _5W2H.Core.Entities;

public class Question : BaseEntity
{
    public Question() { }
    
    public Question(string texto)
    {
        Texto = texto;
    }

    public string Texto { get; set; } // Texto da pergunta
}