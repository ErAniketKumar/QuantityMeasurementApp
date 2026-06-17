using QMAPP.Entities;

namespace QMAPP_NEW.Repositories;

public interface IUserRepository
{
    Task<User?> GetByEmail(string email);

    Task Add(User user);
}