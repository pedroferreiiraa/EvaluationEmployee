using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using _5W2H.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace _5W2H.Infrastructure.Repositories
{
    public class UserAnswerRepository : IUserAnswerRepository
    {
        private readonly EvaluationDbContext _context;

        public UserAnswerRepository(EvaluationDbContext context)
        {
            _context = context;
        }

        public async Task<Answer> GetByIdAsync(int id)
        {
            return await _context.UserAnswers
                .SingleOrDefaultAsync(a => a.Id == id) ?? throw new KeyNotFoundException($"Answer with ID {id} not found.");
        }

        public async Task<IEnumerable<Answer>> GetAnswersByIdsAsync(List<int> ids)
        {
            return await _context.UserAnswers
                .Where(a => ids.Contains(a.Id))
                .ToListAsync();
        }

        public async Task<int> AddAsync(Answer answer)
        {
            await _context.UserAnswers.AddAsync(answer);
            await _context.SaveChangesAsync();
            return answer.Id;
        }

        public async Task<List<Answer>> GetAllAsync()
        {
            return await _context.UserAnswers.ToListAsync();
        }

        public async Task UpdateAsync(Answer answer)
        {
            _context.UserAnswers.Update(answer);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}