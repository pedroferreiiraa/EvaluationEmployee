using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _5W2H.Application.Models;
using MediatR;

namespace _5W2H.Application.Queries.UserQuestionQueries.GetAllUserQuestions
{
    public class GetAllUsersQuestionsQuery : IRequest<ResultViewModel<List<QuestionViewModel>>>
    {
        
    }
}