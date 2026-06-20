using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QMAPP.Data;
using QMAPP.Entities;

namespace QMAPP_NEW.Repositories;

public class UserRepository : IUserRepository
{
    private readonly QmDbContext _context;

    public UserRepository(QmDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(
                x => x.Email == email);
    }

    public async Task Add(User user)
    {
        await _context.Users.AddAsync(user);

        await _context.SaveChangesAsync();
    }

   
}