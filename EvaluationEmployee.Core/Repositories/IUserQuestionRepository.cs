using _5W2H.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _5W2H.Core.Repositories
{
    public interface IUserQuestionRepository
    {
        Task<UserQuestion> GetByIdAsync(int id);                          
        Task<List<UserQuestion>> GetQuestionsByIdsAsync(List<int> ids); 
        Task<int> AddAsync(UserQuestion userQuestion);                         
        Task<List<UserQuestion>> GetAllAsync();                            
        Task UpdateAsync(UserQuestion userQuestion);                      
        Task SaveChangesAsync();                                    
    }
}