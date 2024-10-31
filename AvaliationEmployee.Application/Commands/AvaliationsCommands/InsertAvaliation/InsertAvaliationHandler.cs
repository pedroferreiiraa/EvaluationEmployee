using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using MediatR;
using _5W2H.Application.DTOs; // Adicione esta linha
using _5W2H.Application.Models;

namespace _5W2H.Application.Commands.AvaliationsCommands.InsertAvaliation
{
    public class InsertAvaliationHandler : IRequestHandler<InsertAvaliationCommand, ResultViewModel<int>>
    {
        private readonly IAvaliationRepository _avaliationRepository;
        private readonly IQuestionRepository _questionRepository;

        public InsertAvaliationHandler(IAvaliationRepository avaliationRepository, IQuestionRepository questionRepository)
        {
            _avaliationRepository = avaliationRepository;
            _questionRepository = questionRepository;
        }

        public async Task<ResultViewModel<int>> Handle(InsertAvaliationCommand request, CancellationToken cancellationToken)
        {
            // Validar se os QuestionIds são válidos
            var questionIds = request.Answers.Select(a => a.QuestionId).ToList();
            var validQuestions = await _questionRepository.GetQuestionsByIdsAsync(questionIds);
            if (validQuestions.Count != questionIds.Count)
            {
                return ResultViewModel<int>.Error("Uma ou mais perguntas são inválidas.");
            }

            var avaliation = request.ToEntity();

            await _avaliationRepository.AddAsync(avaliation);
            await _avaliationRepository.SaveChangesAsync();

            return ResultViewModel<int>.Success(avaliation.Id);
        }
    }
}