using System.Linq.Expressions;
using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using _5W2H.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace _5W2H.Infrastructure.Repositories;

public class UserEvaluationRepository : IUserEvaluationRepository
{
    private readonly EvaluationDbContext _context;
    
    public UserEvaluationRepository(EvaluationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<UserEvaluation>> GetAllAsync()
    {
        return await _context.UserAvaliations
            .Include(ua => ua.Answers)
            .ThenInclude(a => a.UserQuestion) 
            .ToListAsync();
    }

    public async Task<UserEvaluation> GetByIdAsync(int id)
    {
        return await _context.UserAvaliations
            .Include(ua => ua.Answers)
            .ThenInclude(a => a.UserQuestion)
            .FirstOrDefaultAsync(ua => ua.Id == id);
    }

    public async Task<List<UserEvaluation>> GetByUserIdAsync(int userId)
    {
        return await _context.UserAvaliations
            .Include(a => a.Questions)
            .Include(a => a.Answers)
            .Where(a => a.EmployeeId == userId)
            .ToListAsync();
    }

    public async Task<UserEvaluation> GetByIdWithActionsAsync(int id)
    {
        return await _context.UserAvaliations
           
            .SingleOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
    }


    public async Task<int> AddAsync(UserEvaluation userEvaluation)
    {
        await _context.UserAvaliations.AddAsync(userEvaluation);
        await _context.SaveChangesAsync(); 
        return userEvaluation.Id;
    }
    

    public async Task UpdateAsync(UserEvaluation userEvaluation)
    {
        _context.UserAvaliations.Update(userEvaluation);
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

    public IQueryable<UserEvaluation> Query()
    {
        return _context.UserAvaliations.AsQueryable();
    }

    public async Task<List<UserEvaluation>> GetEvaluationsByUserIdAsync(int userId)
    {
        return await _context.UserAvaliations
            .Include(ua => ua.Answers)
            .ThenInclude(a => a.UserQuestion)
            .Where(ua => ua.EmployeeId == userId)
            .ToListAsync();
    }

    public async Task<List<UserEvaluation>> GetEvaluationsByOthers(int employeeId)
    {
        // Aqui, vamos filtrar avaliações onde o EvaluatorId não é igual ao EmployeeId.
        return await _context.UserAvaliations
            .Include(ua => ua.Answers)
            .ThenInclude(a => a.UserQuestion)
            .Where(ua => ua.EmployeeId == employeeId && ua.EvaluatorId != employeeId)
            .ToListAsync();
    }



    public async Task<int> DeleteAsync(int id)
    {
        var project =  _context.UserAvaliations.SingleOrDefault(p => p.Id == id);
        
        if (project == null)
            throw new InvalidOperationException("Avaliação não encontrado");
        
        project.SetAsDeleted();
        
        _context.UserAvaliations.Update(project);
        
        await _context.SaveChangesAsync();

        return project.Id;

    }
    
 

    
}