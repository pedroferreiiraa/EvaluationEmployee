using _5W2H.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _5W2H.Core.Repositories
{
    public interface ILeaderQuestionRepository
    {
        Task<LeaderQuestion> GetByIdAsync(int id);                          
        Task<List<LeaderQuestion>> GetQuestionsByIdsAsync(List<int> ids); 
        Task<int> AddAsync(LeaderQuestion userQuestion);                         
        Task<List<LeaderQuestion>> GetAllAsync();                            
        Task UpdateAsync(LeaderQuestion userQuestion);                      
        Task SaveChangesAsync();                                    
    }
}