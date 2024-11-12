using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using _5W2H.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace _5W2H.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly EvaluationDbContext _context;
    
    public UserRepository(EvaluationDbContext context)
    {
        _context = context;
    }
    
    public async Task<User> GetByIdAsync(int id)
    {
        return await _context.Users
            .SingleOrDefaultAsync(u => u.Id == id && !u.IsDeleted);

    }

    public async Task<User> GetUserByEmailAndPassword(string email, string passwordHash)
    {
        var user = await _context
            .Users
            .SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);

        if (user == null || user.IsDeleted)
        {
            return null;
        }

        return user;
    }

    public async Task<User> AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<List<User>> GetAllAsync()
    {
        var users = await _context.Users.ToListAsync();

        return users;
    }

    public async Task Update(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        
    }

 

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);

        if (user == null || user.IsDeleted)
            throw new InvalidOperationException("User não encontrado ou já foi deletado");

        user.SetAsDeleted();
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user.Id;
    }
}