using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.UserQuestionQueries.GetAllUserQuestions
{
    public class GetAllUsersQuestionsHandler : IRequestHandler<GetAllUsersQuestionsQuery, ResultViewModel<List<QuestionViewModel>>>
    {
        private readonly IUserQuestionRepository _userQuestionRepository;

        public GetAllUsersQuestionsHandler(IUserQuestionRepository userQuestionRepository) 
        {
            _userQuestionRepository = userQuestionRepository;
        }

        public async Task<ResultViewModel<List<QuestionViewModel>>> Handle(GetAllUsersQuestionsQuery request, CancellationToken cancellationToken)
        {
            var questions = await _userQuestionRepository.GetAllAsync();
            
            var model = questions.Select(QuestionViewModel.FromEntity).ToList();
            
            return ResultViewModel<List<QuestionViewModel>>.Success(model);
        }
    }
}