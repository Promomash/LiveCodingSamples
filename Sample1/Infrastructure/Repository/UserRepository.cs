using Infrastructure.Context;
using Infrastructure.Interfaces;
using Models;

namespace Infrastructure.Repository;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task SaveUser(User user)
    {
        var result = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }
}