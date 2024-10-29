using _5W2H.Core.Entities;
using _5W2H.Core.Enums;

namespace _5W2H.Application.Models
{
    public class AvaliacaoViewModel
    {
        public int Id { get; set; }
        public string Title { get; private set; }
        public int ProjectNumber { get; private set; }
        public AvaliationStatusEnum Status { get; private set; }
        public int UserId { get; private set; }
        public string OriginDate { get; private set; }

        public DateTime? CreatedAt { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? CompletedAt { get; private set; }
        public bool IsDeleted { get; private set; }
        
        public string Description { get; private set; }
        
        // Somente os IDs das ações
        public List<int> ActionIds { get; private set; }

        public string Origin { get; private set; }
        public int OriginNumber { get; private set; }
        
        public string? ConclusionText { get; private set; }
        
        // Método ToEntity para transformar Project em ProjectViewModel
        public static AvaliacaoViewModel ToEntity(Avaliation avaliation)
        {
            return new AvaliacaoViewModel
            {
           
            };
        }
    }
}