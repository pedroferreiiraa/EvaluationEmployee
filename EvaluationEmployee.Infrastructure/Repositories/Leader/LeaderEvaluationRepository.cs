using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using _5W2H.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace _5W2H.Infrastructure.Repositories;

public class LeaderEvaluationRepository : ILeaderEvaluationRepository
{
    private readonly EvaluationDbContext _context;
    
    public LeaderEvaluationRepository(EvaluationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<LeaderEvaluation>> GetAllAsync()
    {
        return await _context.LeaderAvaliations
            .Include(a => a.LeaderAnswers)
            .ThenInclude(a => a.LeaderQuestion)
            .ToListAsync();
    }

    public async Task<LeaderEvaluation> GetByIdAsync(int id)
    {
        return await _context.LeaderAvaliations
            .Include(ua => ua.LeaderAnswers)
            .ThenInclude(a => a.LeaderQuestion)
            .FirstOrDefaultAsync(ua => ua.Id == id);
    }

 
    public async Task<List<LeaderEvaluation>> GetByLeaderIdAsync(int userId)
    {
        return await _context.LeaderAvaliations
            .Include(a => a.LeaderQuestions)
            .Include(a => a.LeaderAnswers)
            .Where(a => a.EmployeeId == userId)
            .ToListAsync();
    }

    public async Task<LeaderEvaluation> GetByIdWithActionsAsync(int id)
    {
        return await _context.LeaderAvaliations
           
            .SingleOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
    }


    public async Task<int> AddAsync(LeaderEvaluation leaderEvaluation)
    {
        await _context.LeaderAvaliations.AddAsync(leaderEvaluation);
        await _context.SaveChangesAsync(); 
        return leaderEvaluation.Id;
    }
    

    public async Task UpdateAsync(LeaderEvaluation leaderEvaluation)
    {
        _context.LeaderAvaliations.Update(leaderEvaluation);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Exists(int id)
    {
        return await _context.LeaderAvaliations.AnyAsync(p => p.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public IQueryable<LeaderEvaluation> Query()
    {
        return _context.LeaderAvaliations.AsQueryable();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var project =  _context.LeaderAvaliations.SingleOrDefault(p => p.Id == id);
        
        if (project == null)
            throw new InvalidOperationException("Avaliação não encontrada");
        
        project.SetAsDeleted();
        
        _context.LeaderAvaliations.Update(project);
        
        await _context.SaveChangesAsync();

        return project.Id;

    }

    
}