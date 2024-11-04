using _5W2H.Core.Entities;

namespace _5W2H.Core.Repositories;

public interface IUserEvaluationRepository
{
    Task<List<UserEvaluation>> GetAllAsync();
    Task<UserEvaluation> GetByIdAsync(int id);
    Task<List<UserEvaluation>> GetByUserIdAsync(int userId);
    Task<int> AddAsync(UserEvaluation userEvaluation);
    Task UpdateAsync(UserEvaluation userEvaluation);
    Task<int> DeleteAsync(int id);
    Task SaveChangesAsync();
    IQueryable<UserEvaluation> Query();
    
}