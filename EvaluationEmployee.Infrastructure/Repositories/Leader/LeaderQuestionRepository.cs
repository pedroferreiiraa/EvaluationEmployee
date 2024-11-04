using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using _5W2H.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace _5W2H.Infrastructure.Repositories
{
    public class LeaderQuestionRepository : ILeaderQuestionRepository
    {
        private readonly EvaluationDbContext _context;

        public LeaderQuestionRepository(EvaluationDbContext context)
        {
            _context = context;
        }

        public async Task<LeaderQuestion> GetByIdAsync(int id)
        {
            return await _context.LeaderQuestions
                .SingleOrDefaultAsync(q => q.Id == id) ?? throw new KeyNotFoundException($"Question with ID {id} not found.");
        }

        public async Task<List<LeaderQuestion>> GetQuestionsByIdsAsync(List<int> ids)
        {
            return await _context.LeaderQuestions
                .Where(q => ids.Contains(q.Id))
                .ToListAsync();
        }

        public async Task<int> AddAsync(LeaderQuestion leaderQuestion)
        {
            await _context.LeaderQuestions.AddAsync(leaderQuestion);
            await _context.SaveChangesAsync();
            return leaderQuestion.Id;
        }

        public async Task<List<LeaderQuestion>> GetAllAsync()
        {
            return await _context.LeaderQuestions.ToListAsync();
        }

        public async Task UpdateAsync(LeaderQuestion leaderQuestion)
        {
            _context.LeaderQuestions.Update(leaderQuestion);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}