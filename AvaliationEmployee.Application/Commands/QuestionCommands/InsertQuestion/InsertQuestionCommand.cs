using _5W2H.Core.Entities;
using MediatR;

namespace _5W2H.Application.Commands.QuestionCommands.InsertQuestion;

public class InsertQuestionCommand : IRequest<int>
{
    public string Text { get; set; }
    
    public Question ToEntity(string requestText)
        => new(Text);
}
