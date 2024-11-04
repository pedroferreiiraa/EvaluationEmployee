using _5W2H.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _5W2H.Core.Repositories
{
    public interface ILeaderAnswerRepository
    {
        Task<LeaderAnswer> GetByIdAsync(int id);                        
        Task<IEnumerable<LeaderAnswer>> GetAnswersByIdsAsync(List<int> ids);
        Task<int> AddAsync(LeaderAnswer leaderAnswer);                        
        Task<List<LeaderAnswer>> GetAllAsync();                        
        Task UpdateAsync(LeaderAnswer answer);                          
        Task SaveChangesAsync();                                
    }
}