using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.UserAvaliation.UserAvaliationsCommands.InsertUserAvaliation
{
    public class InsertUserAvaliationHandler : IRequestHandler<InsertUserAvaliationCommand, ResultViewModel<int>>
    {
        private readonly IUserEvaluationRepository _userEvaluationRepository;
        private readonly IUserQuestionRepository _userQuestionRepository;

        public InsertUserAvaliationHandler(IUserEvaluationRepository userEvaluationRepository, IUserQuestionRepository userQuestionRepository)
        {
            _userEvaluationRepository = userEvaluationRepository;
            _userQuestionRepository = userQuestionRepository;
        }

        public async Task<ResultViewModel<int>> Handle(InsertUserAvaliationCommand request, CancellationToken cancellationToken)
        {
            // Validar se os QuestionIds são válidos
            var questionIds = request.Answers.Select(a => a.QuestionId).ToList();
            var validQuestions = await _userQuestionRepository.GetQuestionsByIdsAsync(questionIds);
            if (validQuestions.Count != questionIds.Count)
            {
                return ResultViewModel<int>.Error("Uma ou mais perguntas são inválidas.");
            }

            var avaliation = request.ToEntity();

            await _userEvaluationRepository.AddAsync(avaliation);
            await _userEvaluationRepository.SaveChangesAsync();

            return ResultViewModel<int>.Success(avaliation.Id);
        }
    }
}