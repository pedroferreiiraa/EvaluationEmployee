using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using MediatR;
using _5W2H.Application.Models;

namespace _5W2H.Application.Commands.AvaliationsCommands.InsertAvaliation;

public class InsertAvaliationHandler : IRequestHandler<InsertAvaliationCommand, ResultViewModel<int>>
{
    private readonly IAvaliationRepository _avaliationRepository;
    private readonly IQuestionRepository _questionRepository;
    private readonly IAnswerRepository _answerRepository;

    public InsertAvaliationHandler(IAvaliationRepository avaliationRepository, 
        IQuestionRepository questionRepository, 
        IAnswerRepository answerRepository)
    {
        _avaliationRepository = avaliationRepository;
        _questionRepository = questionRepository;
        _answerRepository = answerRepository;
    }

    public async Task<ResultViewModel<int>> Handle(InsertAvaliationCommand request, CancellationToken cancellationToken)
    {
        // 1. Busque as perguntas associadas e converta para List<Question>
        var questions = (await _questionRepository.GetQuestionsByIdsAsync(request.QuestionIds)).ToList();
        
        // 2. Busque as respostas, se forem parte da criação, e converta para List<Answer>
        var answers = new List<Answer>();
        if (request.AnswerIds.Count > 0)
        {
            answers = (await _answerRepository.GetAnswersByIdsAsync(request.AnswerIds)).ToList();
        }

        // 3. Crie a nova Avaliação
        var avaliation = new Avaliation(
            request.EmployeeId,
            request.AvaliadorId,
            answers,
            questions
        );

        // 4. Salve a avaliação no repositório
        await _avaliationRepository.AddAsync(avaliation);
        await _avaliationRepository.SaveChangesAsync();

        return ResultViewModel<int>.Success(avaliation.Id);
    }
}