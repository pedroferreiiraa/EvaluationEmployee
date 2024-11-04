using _5W2H.Core.Entities;

namespace _5W2H.Core.Repositories;

public interface IUserAvaliationRepository
{
    Task<List<UserAvaliation>> GetAllAsync();
    Task<UserAvaliation> GetByIdAsync(int id);
    Task<List<UserAvaliation>> GetByUserIdAsync(int userId);
    Task<int> AddAsync(UserAvaliation userAvaliation);
    Task UpdateAsync(UserAvaliation userAvaliation);
    Task<int> DeleteAsync(int id);
    Task SaveChangesAsync();
    IQueryable<UserAvaliation> Query();
    
}