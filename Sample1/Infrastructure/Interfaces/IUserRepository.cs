using Models;

namespace Infrastructure.Interfaces;

public interface IUserRepository
{
    Task SaveUser(User user);
}