using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.ProjectsCommands.DeleteProject;

public class DeleteAvaliationHandler : IRequestHandler<DeleteAvaliationCommand, ResultViewModel<int>>
{
    private readonly IAvaliationRepository _avaliationRepository;

    public DeleteAvaliationHandler(IAvaliationRepository avaliationRepository)
    {
        _avaliationRepository = avaliationRepository;
    }

    
    public async Task<ResultViewModel<int>> Handle(DeleteAvaliationCommand request, CancellationToken cancellationToken)
    {
        var existingProject = await _avaliationRepository.GetByIdAsync(request.Id);
        
        if (existingProject == null)
        {
            return ResultViewModel<int>.Error("Projeto não encontrado");
        }
        
        await _avaliationRepository.DeleteAsync(request.Id);
        
        return ResultViewModel<int>.Success(request.Id);
    }
}