using Microsoft.EntityFrameworkCore;
using MotorON.Domain.Entities;
using MotorON.Domain.Interfaces;
using MotorON.Infrastructure.Data;

namespace MotorON.Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }
}
