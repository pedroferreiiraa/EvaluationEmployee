using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.UserAvaliationQueries.GetUserAvaliationById
{
    public class GetUserAvaliationByIdHandler : IRequestHandler<GetUserAvaliationByIdQuery, UserAvaliationViewModel>
    {
        private readonly IUserAvaliationRepository _repository;

        public GetUserAvaliationByIdHandler(IUserAvaliationRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<UserAvaliationViewModel> Handle(GetUserAvaliationByIdQuery request, CancellationToken cancellationToken)
        {
            var avaliation = await _repository.GetByIdAsync(request.Id);

            if (avaliation == null)
            {
                return null;
            }

            var viewModel = new UserAvaliationViewModel
            {
                AvaliationId = avaliation.Id,
                EmployeeId = avaliation.EmployeeId,
                Questions = avaliation.Questions.Select(q => new QuestionViewModel
                {
                    QuestionId = q.Id,
                    Text = q.Text
                    // Outros mapeamentos, se necessário
                }).ToList(),
                Answers = avaliation.Answers.Select(a => new AnswerViewModel
                {
                    AnswerId = a.Id,
                    QuestionId = a.QuestionId,
                    AnswerNumber = a.AnswerNumber
                    // Outros mapeamentos, se necessário
                }).ToList()
            };

            return viewModel;
        }
    }
}