using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using _5W2H.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace _5W2H.Infrastructure.Repositories;

public class UserAvaliationRepository : IUserAvaliationRepository
{
    private readonly AvaliationDbContext _context;
    
    public UserAvaliationRepository(AvaliationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<UserAvaliation>> GetAllAsync()
    {
        return await _context.UserAvaliations
            .Include(a => a.Questions)
            .Include(a => a.Answers)
            .ToListAsync();
    }

    public async Task<UserAvaliation> GetByIdAsync(int id)
    {
        return await _context.UserAvaliations
            .Include(ua => ua.Questions)
            .Include(ua => ua.Answers)
            .FirstOrDefaultAsync(ua => ua.Id == id);
    }

    public async Task<List<UserAvaliation>> GetByUserIdAsync(int userId)
    {
        return await _context.UserAvaliations
            .Include(a => a.Questions)
            .Include(a => a.Answers)
            .Where(a => a.EmployeeId == userId)
            .ToListAsync();
    }

    public async Task<UserAvaliation> GetByIdWithActionsAsync(int id)
    {
        return await _context.UserAvaliations
           
            .SingleOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
    }


    public async Task<int> AddAsync(UserAvaliation userAvaliation)
    {
        await _context.UserAvaliations.AddAsync(userAvaliation);
        await _context.SaveChangesAsync(); 
        return userAvaliation.Id;
    }
    

    public async Task UpdateAsync(UserAvaliation userAvaliation)
    {
        _context.UserAvaliations.Update(userAvaliation);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Exists(int id)
    {
        return await _context.UserAvaliations.AnyAsync(p => p.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public IQueryable<UserAvaliation> Query()
    {
        return _context.UserAvaliations.AsQueryable();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var project =  _context.UserAvaliations.SingleOrDefault(p => p.Id == id);
        
        if (project == null)
            throw new InvalidOperationException("Projeto não encontrado");
        
        project.SetAsDeleted();
        
        _context.UserAvaliations.Update(project);
        
        await _context.SaveChangesAsync();

        return project.Id;

    }

    
}