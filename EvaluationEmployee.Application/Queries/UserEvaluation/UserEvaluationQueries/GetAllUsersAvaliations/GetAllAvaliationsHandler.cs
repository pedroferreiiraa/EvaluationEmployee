using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.UserAvaliationQueries.GetAllUsersAvaliations
{
   public class GetAllAvaliationsHandler : IRequestHandler<GetAllAvaliationsQuery, List<UserEvaluationViewModel>>
{
    private readonly IUserEvaluationRepository _userEvaluationRepository;

    public GetAllAvaliationsHandler(IUserEvaluationRepository userEvaluationRepository)
    {
        _userEvaluationRepository = userEvaluationRepository;
    }

    public async Task<List<UserEvaluationViewModel>> Handle(GetAllAvaliationsQuery request, CancellationToken cancellationToken)
    {
        var avaliations = await _userEvaluationRepository.GetAllAsync();

        var avaliationViewModels = avaliations.Select(avaliation => new UserEvaluationViewModel
        {
            AvaliationId = avaliation.Id,
            EmployeeId = avaliation.EmployeeId,
            EvaluatorId = avaliation.EvaluatorId,
            Questions = avaliation.Questions.Select(q => new QuestionViewModel
            {
                QuestionId = q.Id,
                Text = q.Text,
                Topic = q.Topic,
            }).ToList(),
            Answers = avaliation.Answers.Select(a => new AnswerViewModel
            {
                AnswerId = a.Id,    
                QuestionId = a.QuestionId,
                AnswerNumber = a.AnswerNumber
            }).ToList()
        }).ToList();

        return avaliationViewModels;
    }
}
}