using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.UserAvaliationQueries.GetAllUsersAvaliations
{
    
    public class TopicAverageViewModel
    {
        public string Topic { get; set; } // Nome do tópico
        public double Average { get; set; } // Média das respostas
    }

    public class GetAllEvaluationsHandler : IRequestHandler<GetAllEvaluationsQuery, List<UserEvaluationViewModel>>
    {
        private readonly IUserEvaluationRepository _userEvaluationRepository;

        public GetAllEvaluationsHandler(IUserEvaluationRepository userEvaluationRepository)
        {
            _userEvaluationRepository = userEvaluationRepository;
        }

        public async Task<List<UserEvaluationViewModel>> Handle(GetAllEvaluationsQuery request,
            CancellationToken cancellationToken)
        {
            var evaluations = await _userEvaluationRepository.GetAllAsync();

            
            var evaluationViewModels = evaluations
                .Select(UserEvaluationViewModel.FromEntity)
                .ToList();

            return evaluationViewModels;
        }
    }
}