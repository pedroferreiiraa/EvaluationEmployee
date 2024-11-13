using _5W2H.Application.DTOs;
using _5W2H.Application.Models;
using _5W2H.Core.Enums;
using MediatR;

namespace _5W2H.Application.Commands.UserAvaliation.UserAvaliationsCommands.InsertUserAvaliation
{
    public class InsertUserEvaluationCommand : IRequest<ResultViewModel<int>>
    {
        public int EmployeeId { get; set; }
        public int EvaluatorId { get; set; }
        
        public EvaluationStatusEnum Status { get; set; }
        public string DateReference { get; set; }
        public string? ImprovePoints { get;  set;}
        public string? Pdi { get;  set; }
        public string? Goals { get;  set; }
        public string? SixMonthAlignment { get;  set; }
        public List<UserAnswerDto> Answers { get; set; } = new List<UserAnswerDto>();
        

        public Core.Entities.UserEvaluation ToEntity()
        {
            var avaliation = new Core.Entities.UserEvaluation(EmployeeId, EvaluatorId, Status, DateReference, ImprovePoints, Pdi, Goals, SixMonthAlignment);
            foreach (var answerDto in Answers)
            {
                avaliation.AddAnswer(answerDto.QuestionId, answerDto.AnswerNumber);
            }
            return avaliation;
        }
    }
}