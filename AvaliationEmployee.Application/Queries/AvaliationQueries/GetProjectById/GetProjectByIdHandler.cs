using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace _5W2H.Application.Queries.ProjectQueries.GetProjectById;

public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, ResultViewModel<AvaliacaoViewModel>>
{
    private readonly IAvaliationRepository _avaliationRepository;

    public GetProjectByIdHandler(IAvaliationRepository avaliationRepository)
    {
        _avaliationRepository = avaliationRepository;
    }
    
    
    
    public async Task<ResultViewModel<AvaliacaoViewModel>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await _avaliationRepository.Query()
            
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (project == null)
        {
            return ResultViewModel<AvaliacaoViewModel>.Error("Projeto não encontrado.");
        }

        // Log para verificar se as ações estão sendo carregadas
   

        return ResultViewModel<AvaliacaoViewModel>.Success(AvaliacaoViewModel.ToEntity(project));
    }
}