using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using _5W2H.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace _5W2H.Infrastructure.Repositories
{
    public class LeaderAnswerRepository : ILeaderAnswerRepository
    {
        private readonly EvaluationDbContext _context;

        public LeaderAnswerRepository(EvaluationDbContext context)
        {
            _context = context;
        }

        public async Task<LeaderAnswer> GetByIdAsync(int id)
        {
            return await _context.LeaderAnswers
                .SingleOrDefaultAsync(a => a.Id == id) ?? throw new KeyNotFoundException($"Answer with ID {id} not found.");
        }

        public async Task<IEnumerable<LeaderAnswer>> GetAnswersByIdsAsync(List<int> ids)
        {
            return await _context.LeaderAnswers
                .Where(a => ids.Contains(a.Id))
                .ToListAsync();
        }

     

        public async Task<int> AddAsync(LeaderAnswer leaderAnswer)
        {
            await _context.LeaderAnswers.AddAsync(leaderAnswer);
            await _context.SaveChangesAsync();
            return leaderAnswer.Id;
        }

        public async Task<List<LeaderAnswer>> GetAllAsync()
        {
            return await _context.LeaderAnswers.ToListAsync();
        }

     

        public async Task UpdateAsync(LeaderAnswer leaderAnswer)
        {
            _context.LeaderAnswers.Update(leaderAnswer);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}