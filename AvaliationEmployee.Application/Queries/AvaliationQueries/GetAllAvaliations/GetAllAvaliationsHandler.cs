using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.AvaliationQueries.GetAllAvaliations
{
   public class GetAllAvaliationsHandler : IRequestHandler<GetAllAvaliationsQuery, List<AvaliationViewModel>>
{
    private readonly IAvaliationRepository _avaliationRepository;

    public GetAllAvaliationsHandler(IAvaliationRepository avaliationRepository)
    {
        _avaliationRepository = avaliationRepository;
    }

    public async Task<List<AvaliationViewModel>> Handle(GetAllAvaliationsQuery request, CancellationToken cancellationToken)
    {
        var avaliations = await _avaliationRepository.GetAllAsync();

        var avaliationViewModels = avaliations.Select(avaliation => new AvaliationViewModel
        {
            AvaliationId = avaliation.Id,
            EmployeeId = avaliation.EmployeeId,
            Questions = avaliation.Questions.Select(q => new QuestionViewModel
            {
                QuestionId = q.Id,
                Text = q.Text
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