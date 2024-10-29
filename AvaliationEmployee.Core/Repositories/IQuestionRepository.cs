using _5W2H.Core.Entities;

namespace _5W2H.Core.Repositories;

public interface IQuestionRepository
{
    Task<Question> GetByIdAsync(int id);
    Task<int> AddAsync(Question question);
    Task<List<Question>> GetAllAsync();
    Task UpdateAsync(Question question);
    Task SaveChangesAsync();

}