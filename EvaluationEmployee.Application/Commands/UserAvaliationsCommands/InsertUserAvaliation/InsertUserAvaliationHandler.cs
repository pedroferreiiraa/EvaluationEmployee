using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;
// Adicione esta linha

namespace _5W2H.Application.Commands.UserAvaliationsCommands.InsertUserAvaliation
{
    public class InsertUserAvaliationHandler : IRequestHandler<InsertUserAvaliationCommand, ResultViewModel<int>>
    {
        private readonly IUserAvaliationRepository _userAvaliationRepository;
        private readonly IUserQuestionRepository _userQuestionRepository;

        public InsertUserAvaliationHandler(IUserAvaliationRepository userAvaliationRepository, IUserQuestionRepository userQuestionRepository)
        {
            _userAvaliationRepository = userAvaliationRepository;
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

            await _userAvaliationRepository.AddAsync(avaliation);
            await _userAvaliationRepository.SaveChangesAsync();

            return ResultViewModel<int>.Success(avaliation.Id);
        }
    }
}