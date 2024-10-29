using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using _5W2H.Core.Enums;
using _5W2H.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;

namespace _5W2H.Application.Queries.ProjectQueries.GetAllProjects
{
    public class GetAllAvaliationsHandler : IRequestHandler<GetAllAvaliationsQuery, ResultViewModel<PaginatedList<AvaliacaoViewModel>>>
    {
        private readonly IAvaliationRepository _avaliationRepository;

        public GetAllAvaliationsHandler(IAvaliationRepository avaliationRepository)
        {
            _avaliationRepository = avaliationRepository;
        }

        public async Task<ResultViewModel<PaginatedList<AvaliacaoViewModel>>> Handle(GetAllAvaliationsQuery request, CancellationToken cancellationToken)
        {
            // Start with var to let the compiler infer the correct type
            IQueryable<Avaliation> projectsQuery = _avaliationRepository.Query();


            // Apply filters
            if (request.Status >= 0)
            {
                var projectStatus = (AvaliationStatusEnum)request.Status;
                projectsQuery = projectsQuery.Where(p => p.Status == projectStatus);
            }

            projectsQuery = projectsQuery.OrderByDescending(p => p.CreatedAt);
            
            // Get total count for pagination
            var totalItems = await projectsQuery.CountAsync(cancellationToken);

            // Apply pagination
            var pagedProjects = await projectsQuery
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            // Check if any projects were found
            if (!pagedProjects.Any())
            {
                return ResultViewModel<PaginatedList<AvaliacaoViewModel>>.Error("Nenhum projeto encontrado.");
            }

            // Map to ViewModel
            var projectViewModels = pagedProjects.Select(AvaliacaoViewModel.ToEntity).ToList();

            // Return paginated list
            return ResultViewModel<PaginatedList<AvaliacaoViewModel>>.Success(
                new PaginatedList<AvaliacaoViewModel>(projectViewModels, totalItems, request.PageNumber, request.PageSize)
            );
        }

    }
}