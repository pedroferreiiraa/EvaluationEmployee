using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.ProjectsCommands.StartProject;

public class StartAvaliationHandler : IRequestHandler<StartAvaliationCommand, ResultViewModel<Avaliation>>
{
    private readonly IAvaliationRepository _avaliationRepository;

    public StartAvaliationHandler(IAvaliationRepository avaliationRepository)
    {
        _avaliationRepository = avaliationRepository;
    }
    
    public async Task<ResultViewModel<Avaliation>> Handle(StartAvaliationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Usar o método StartAsync do repositório
            var updatedProject = await _avaliationRepository.StartAsync(request.Id);

            // Retornar o projeto atualizado como JSON
            return ResultViewModel<Avaliation>.Success(updatedProject);
        }
        catch (InvalidOperationException ex)
        {
            // Retornar erro em um formato que o frontend possa interpretar
            return ResultViewModel<Avaliation>.Error(ex.Message);
        }
        catch (Exception ex)
        {
            return ResultViewModel<Avaliation>.Error($"Erro desconhecido: {ex.Message}");
        }
    }
}