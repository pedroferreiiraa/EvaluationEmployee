using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.ProjectsCommands.CompleteProject;

public class CompleteAvaliationHandler : IRequestHandler<CompleteAvaliationCommand, ResultViewModel<Avaliation>>
{
    
    private readonly IAvaliationRepository _avaliationRepository;

    public CompleteAvaliationHandler(IAvaliationRepository avaliationRepository)
    {
        _avaliationRepository = avaliationRepository;
    }

    public async Task<ResultViewModel<Avaliation>> Handle(CompleteAvaliationCommand request, CancellationToken cancellationToken)
    {
        var existingProject = await _avaliationRepository.GetByIdAsync(request.Id);

        if (existingProject == null)
        {
            return ResultViewModel<Avaliation>.Error("Projeto não encontrado");
        }
        

        await _avaliationRepository.SaveChangesAsync();
        
        return ResultViewModel<Avaliation>.Success(existingProject);
    }
}