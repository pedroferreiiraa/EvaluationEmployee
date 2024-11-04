using _5W2H.Application.Models;
using MediatR;

namespace _5W2H.Application.Queries.LeaderAvaliation.LeaderQuestionQueries.GetAllLeaderQuestions;

public class GetAllLeadersQuestionsQuery : IRequest<ResultViewModel<List<LeaderQuestionViewModel>>>
{
    
}