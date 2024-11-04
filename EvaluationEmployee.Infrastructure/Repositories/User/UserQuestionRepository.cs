using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using _5W2H.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace _5W2H.Infrastructure.Repositories
{
    public class UserQuestionRepository : IUserQuestionRepository
    {
        private readonly AvaliationDbContext _context;

        public UserQuestionRepository(AvaliationDbContext context)
        {
            _context = context;
        }

        public async Task<UserQuestion> GetByIdAsync(int id)
        {
            return await _context.Questions
                .SingleOrDefaultAsync(q => q.Id == id) ?? throw new KeyNotFoundException($"Question with ID {id} not found.");
        }

        public async Task<List<UserQuestion>> GetQuestionsByIdsAsync(List<int> ids)
        {
            return await _context.Questions
                .Where(q => ids.Contains(q.Id))
                .ToListAsync();
        }

        public async Task<int> AddAsync(UserQuestion userQuestion)
        {
            await _context.Questions.AddAsync(userQuestion);
            await _context.SaveChangesAsync();
            return userQuestion.Id;
        }

        public async Task<List<UserQuestion>> GetAllAsync()
        {
            return await _context.Questions.ToListAsync();
        }

        public async Task UpdateAsync(UserQuestion userQuestion)
        {
            _context.Questions.Update(userQuestion);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}