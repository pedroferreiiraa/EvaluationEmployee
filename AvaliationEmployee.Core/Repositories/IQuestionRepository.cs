using _5W2H.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _5W2H.Core.Repositories
{
    public interface IQuestionRepository
    {
        Task<Question> GetByIdAsync(int id);                          
        Task<IEnumerable<Question>> GetQuestionsByIdsAsync(List<int> ids); 
        Task<int> AddAsync(Question question);                         
        Task<List<Question>> GetAllAsync();                            
        Task UpdateAsync(Question question);                      
        Task SaveChangesAsync();                                    
    }
}