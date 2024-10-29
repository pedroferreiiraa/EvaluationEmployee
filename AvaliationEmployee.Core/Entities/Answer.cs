namespace _5W2H.Core.Entities;

public class Answer : BaseEntity
{
    public Answer(int avaliacaoId, Avaliation avaliation, int perguntaId, Question question, string textoResposta)
    {
        AvaliacaoId = avaliacaoId;
        Avaliation = avaliation;
        PerguntaId = perguntaId;
        Question = question;
        TextoResposta = textoResposta;
    }

    public int AvaliacaoId { get; set; }
    public Avaliation Avaliation { get; set; }
    public int PerguntaId { get; set; }
    public Question Question { get; set; }
    public string TextoResposta { get; set; } // Resposta para a pergunta
}