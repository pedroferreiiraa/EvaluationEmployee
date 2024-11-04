using _5W2H.Core.Entities;

namespace _5W2H.Core.Repositories;

public interface ILeaderAvaliationRepository
{
    Task<List<LeaderAvaliation>> GetAllAsync();
    Task<LeaderAvaliation> GetByIdAsync(int id);
    Task<List<LeaderAvaliation>> GetByLeaderIdAsync(int userId);
    Task<int> AddAsync(LeaderAvaliation leaderAvaliation);
    Task UpdateAsync(LeaderAvaliation leaderAvaliation);
    Task<int> DeleteAsync(int id);
    Task SaveChangesAsync();
    IQueryable<LeaderAvaliation> Query();
    
}