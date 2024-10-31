using _5W2H.Application.DTOs;
using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using MediatR;

namespace _5W2H.Application.Commands.AvaliationsCommands.InsertAvaliation
{
    public class InsertAvaliationCommand : IRequest<ResultViewModel<int>>
    {
        public int EmployeeId { get; set; }
        
        public List<AnswerDto> Answers { get; set; } = new List<AnswerDto>();

        public Avaliation ToEntity()
        {
            var avaliation = new Avaliation(EmployeeId);
            foreach (var answerDto in Answers)
            {
                avaliation.AddAnswer(answerDto.QuestionId, answerDto.AnswerNumber);
            }
            return avaliation;
        }
    }
}