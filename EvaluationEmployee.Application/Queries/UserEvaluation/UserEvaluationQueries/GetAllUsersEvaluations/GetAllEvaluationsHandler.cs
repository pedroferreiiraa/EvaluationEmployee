using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.UserAvaliationQueries.GetAllUsersAvaliations
{
   public class GetAllEvaluationsHandler : IRequestHandler<GetAllEvaluationsQuery, List<UserEvaluationViewModel>>
{
    private readonly IUserEvaluationRepository _userEvaluationRepository;

    public GetAllEvaluationsHandler(IUserEvaluationRepository userEvaluationRepository)
    {
        _userEvaluationRepository = userEvaluationRepository;
    }

    public async Task<List<UserEvaluationViewModel>> Handle(GetAllEvaluationsQuery request, CancellationToken cancellationToken)
    {
        var avaliations = await _userEvaluationRepository.GetAllAsync();

        var avaliationViewModels = avaliations.Select(avaliation => new UserEvaluationViewModel
        {
            AvaliationId = avaliation.Id,
            EmployeeId = avaliation.EmployeeId,
            EvaluatorId = avaliation.EvaluatorId,
            DateReference = avaliation.DateReference,
            Status = avaliation.Status,
            CompletedAt = avaliation.CompletedAt,
            
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