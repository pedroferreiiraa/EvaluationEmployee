using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using _5W2H.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace _5W2H.Infrastructure.Repositories;

public class AvaliationRepository : IAvaliationRepository
{
    private readonly WhoDbContext _context;
    
    public AvaliationRepository(WhoDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Avaliation>> GetAllAsync()
    {
        return await _context.Avaliations
            .Include(a => a.Questions)
            .Include(a => a.Answers)
            .ToListAsync();
    }

    public async Task<Avaliation> GetByIdAsync(int id)
    {
        return await _context.Avaliations
            .SingleOrDefaultAsync(u => u.Id == id && !u.IsDeleted);
    }
    
    public async Task<Avaliation> GetByIdWithActionsAsync(int id)
    {
        return await _context.Avaliations
           
            .SingleOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
    }


    public async Task<int> AddAsync(Avaliation avaliation)
    {
        await _context.Avaliations.AddAsync(avaliation);
        await _context.SaveChangesAsync(); 
        return avaliation.Id;
    }
    

    public async Task UpdateAsync(Avaliation avaliation)
    {
        _context.Avaliations.Update(avaliation);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Exists(int id)
    {
        return await _context.Avaliations.AnyAsync(p => p.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public IQueryable<Avaliation> Query()
    {
        return _context.Avaliations.AsQueryable();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var project =  _context.Avaliations.SingleOrDefault(p => p.Id == id);
        
        if (project == null)
            throw new InvalidOperationException("Projeto não encontrado");
        
        project.SetAsDeleted();
        
        _context.Avaliations.Update(project);
        
        await _context.SaveChangesAsync();

        return project.Id;

    }

    
}