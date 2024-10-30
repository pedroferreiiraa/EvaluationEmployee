using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using MediatR;

namespace _5W2H.Application.Commands.AnswersCommands.InsertAnswer;

public class InsertAnswerCommand : IRequest<ResultViewModel<int>>
{
    public int QuestionId { get; set; }
    public int AvaliationId { get; set; }
    public int AnswerNumber { get; set; }
    
    public Answer ToEntity()
        => new(QuestionId, AvaliationId, AnswerNumber);
}