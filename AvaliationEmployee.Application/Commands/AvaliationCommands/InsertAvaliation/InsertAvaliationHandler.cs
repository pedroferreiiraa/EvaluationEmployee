using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.ProjectsCommands.InsertProject;

public class InsertAvaliationHandler : IRequestHandler<InsertAvaliationCommand, ResultViewModel<int>>
{
    private readonly IAvaliationRepository _avaliationRepository;

    public InsertAvaliationHandler(IAvaliationRepository avaliationRepository)
    {
        _avaliationRepository = avaliationRepository;
    }
    
    public async Task<ResultViewModel<int>> Handle(InsertAvaliationCommand request, CancellationToken cancellationToken)
    {
        var project = request.ToEntity();
        
        await _avaliationRepository.AddAsync(project);
        
        return new ResultViewModel<int>(project.Id);
        
    }
}