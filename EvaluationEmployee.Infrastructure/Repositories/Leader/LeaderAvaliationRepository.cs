using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using _5W2H.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace _5W2H.Infrastructure.Repositories;

public class LeaderAvaliationRepository : ILeaderAvaliationRepository
{
    private readonly AvaliationDbContext _context;
    
    public LeaderAvaliationRepository(AvaliationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<LeaderAvaliation>> GetAllAsync()
    {
        return await _context.LeaderAvaliations
            .Include(a => a.LeaderQuestions)
            .Include(a => a.LeaderAnswers)
            .ToListAsync();
    }

    public async Task<LeaderAvaliation> GetByIdAsync(int id)
    {
        return await _context.LeaderAvaliations
            .Include(ua => ua.LeaderQuestions)
            .Include(ua => ua.LeaderAnswers)
            .FirstOrDefaultAsync(ua => ua.Id == id);
    }

 
    public async Task<List<LeaderAvaliation>> GetByLeaderIdAsync(int userId)
    {
        return await _context.LeaderAvaliations
            .Include(a => a.LeaderQuestions)
            .Include(a => a.LeaderAnswers)
            .Where(a => a.EmployeeId == userId)
            .ToListAsync();
    }

    public async Task<LeaderAvaliation> GetByIdWithActionsAsync(int id)
    {
        return await _context.LeaderAvaliations
           
            .SingleOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
    }


    public async Task<int> AddAsync(LeaderAvaliation leaderAvaliation)
    {
        await _context.LeaderAvaliations.AddAsync(leaderAvaliation);
        await _context.SaveChangesAsync(); 
        return leaderAvaliation.Id;
    }
    

    public async Task UpdateAsync(LeaderAvaliation leaderAvaliation)
    {
        _context.LeaderAvaliations.Update(leaderAvaliation);
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

    public IQueryable<LeaderAvaliation> Query()
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