using _5W2H.Core.Entities;

namespace _5W2H.Core.Repositories;

public interface ILeaderEvaluationRepository
{
    Task<List<LeaderEvaluation>> GetAllAsync();
    Task<LeaderEvaluation> GetByIdAsync(int id);
    Task<List<LeaderEvaluation>> GetByLeaderIdAsync(int userId);
    Task<int> AddAsync(LeaderEvaluation leaderEvaluation);
    Task UpdateAsync(LeaderEvaluation leaderEvaluation);
    Task<int> DeleteAsync(int id);
    Task SaveChangesAsync();
    IQueryable<LeaderEvaluation> Query();
    Task<List<LeaderEvaluation>> GetEvaluationsByLeaderIdAsync(int userId);
    Task<List<LeaderEvaluation>> GetLeaderEvaluationsByOthers(int leaderId);
    
}