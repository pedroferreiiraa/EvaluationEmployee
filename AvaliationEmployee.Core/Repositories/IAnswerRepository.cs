using _5W2H.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _5W2H.Core.Repositories
{
    public interface IAnswerRepository
    {
        Task<Answer> GetByIdAsync(int id);                        
        Task<IEnumerable<Answer>> GetAnswersByIdsAsync(List<int> ids);
        Task<int> AddAsync(Answer answer);                        
        Task<List<Answer>> GetAllAsync();                        
        Task UpdateAsync(Answer answer);                          
        Task SaveChangesAsync();                                
    }
}