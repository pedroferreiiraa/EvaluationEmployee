using _5W2H.Application.DTOs;
using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using MediatR;

namespace _5W2H.Application.Commands.UserAvaliationsCommands.InsertUserAvaliation
{
    public class InsertUserAvaliationCommand : IRequest<ResultViewModel<int>>
    {
        public int EmployeeId { get; set; }
        public int EvaluatorId { get; set; }
        public List<UserAnswerDto> Answers { get; set; } = new List<UserAnswerDto>();

        public UserAvaliation ToEntity()
        {
            var avaliation = new UserAvaliation(EmployeeId, EvaluatorId);
            foreach (var answerDto in Answers)
            {
                avaliation.AddAnswer(answerDto.QuestionId, answerDto.AnswerNumber);
            }
            return avaliation;
        }
    }
}