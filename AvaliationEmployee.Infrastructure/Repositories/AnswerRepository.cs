using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using _5W2H.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _5W2H.Infrastructure.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly WhoDbContext _context;

        public AnswerRepository(WhoDbContext context)
        {
            _context = context;
        }

        public async Task<Answer> GetByIdAsync(int id)
        {
            return await _context.Answers
                .SingleOrDefaultAsync(a => a.Id == id) ?? throw new KeyNotFoundException($"Answer with ID {id} not found.");
        }

        public async Task<IEnumerable<Answer>> GetAnswersByIdsAsync(List<int> ids)
        {
            return await _context.Answers
                .Where(a => ids.Contains(a.Id))
                .ToListAsync();
        }

        public async Task<int> AddAsync(Answer answer)
        {
            await _context.Answers.AddAsync(answer);
            await _context.SaveChangesAsync();
            return answer.Id;
        }

        public async Task<List<Answer>> GetAllAsync()
        {
            return await _context.Answers.ToListAsync();
        }

        public async Task UpdateAsync(Answer answer)
        {
            _context.Answers.Update(answer);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}