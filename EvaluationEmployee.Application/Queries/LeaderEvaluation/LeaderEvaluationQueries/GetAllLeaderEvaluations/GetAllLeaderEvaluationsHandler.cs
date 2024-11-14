using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using _5W2H.Infrastructure.Persistence.Migrations;
using MediatR;

namespace _5W2H.Application.Queries.LeaderAvaliation.LeaderAvaliationQueries.GetAllLeaderAvaliations;


public class TopicLeaderAverageViewModel
{
    public string Topic { get; set; } // Nome do tópico
    public double Average { get; set; } // Média das respostas
}


public class GetAllLeaderEvaluationsHandler : IRequestHandler<GetAllLeaderEvaluationsQuery, List<LeaderEvaluationViewModel>>
{
    private readonly ILeaderEvaluationRepository _leaderEvaluationRepository;

    public GetAllLeaderEvaluationsHandler(ILeaderEvaluationRepository leaderEvaluationRepository)
    {
        _leaderEvaluationRepository = leaderEvaluationRepository;
    }

    
    public async Task<List<LeaderEvaluationViewModel>> Handle(GetAllLeaderEvaluationsQuery request, CancellationToken cancellationToken )
    {
        var evaluations = await _leaderEvaluationRepository.GetAllAsync();
        
        var evaluationViewModels = evaluations
            .Select(LeaderEvaluationViewModel.FromEntity)
            .ToList();

        return evaluationViewModels;
    }
    
}
