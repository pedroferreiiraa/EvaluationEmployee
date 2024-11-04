using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.LeaderAvaliation.LeaderQuestionQueries.GetAllLeaderQuestions;

public class GetAllLeaderQuestionsHandler : IRequestHandler<GetAllLeadersQuestionsQuery, ResultViewModel<List<LeaderQuestionViewModel>>>
{
    private readonly ILeaderQuestionRepository _leaderQuestionRepository;

    public GetAllLeaderQuestionsHandler(ILeaderQuestionRepository leaderQuestionRepository) 
    {
        _leaderQuestionRepository = leaderQuestionRepository;
    }
    
    
    
    public async Task<ResultViewModel<List<LeaderQuestionViewModel>>> Handle(GetAllLeadersQuestionsQuery request, CancellationToken cancellationToken)
    {
        var questions = await _leaderQuestionRepository.GetAllAsync();
            
        var model = questions.Select(LeaderQuestionViewModel.FromEntity).ToList();
            
        return ResultViewModel<List<LeaderQuestionViewModel>>.Success(model);
    }
}