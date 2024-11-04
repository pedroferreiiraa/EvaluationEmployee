using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using _5W2H.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace _5W2H.Infrastructure.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly EvaluationDbContext _context;
    
    public DepartmentRepository(EvaluationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Department> GetByIdAsync(int id)
    {
        return await _context.Departments
            .Include(dp => dp.Users)
            .SingleOrDefaultAsync(d => d.Id == id) ?? throw new KeyNotFoundException();
    }

    public async Task<int> AddAsync(Department department)
    {
        await _context.Departments.AddAsync(department);
        await _context.SaveChangesAsync();
        return department.Id;
    }

    public async Task<List<Department>> GetAllAsync()
    {
        return await _context.Departments.Include(dp => dp.Users).ToListAsync();
    }

    public async Task UpdateAsync(Department department)
    {
        _context.Departments.Update(department);
        await _context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}