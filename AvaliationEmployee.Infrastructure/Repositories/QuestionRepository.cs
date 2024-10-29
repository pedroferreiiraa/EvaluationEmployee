using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using _5W2H.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace _5W2H.Infrastructure.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly WhoDbContext _context;

    public QuestionRepository(WhoDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<Question> GetByIdAsync(int id)
    {
        return await _context.Questions
            .SingleOrDefaultAsync(q => q.Id == id) ?? throw new KeyNotFoundException();
    }

    public async Task<int> AddAsync(Question question)
    {
        await _context.Questions.AddAsync(question);
        await _context.SaveChangesAsync();
        return question.Id;
    }

    public async Task<List<Question>> GetAllAsync()
    {
        var questions = await _context.Questions.ToListAsync();
        return questions.ToList();
    }

    public async Task UpdateAsync(Question question)
    {
        _context.Questions.Update(question);
        await _context.SaveChangesAsync();
        
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync(); 
    }
}