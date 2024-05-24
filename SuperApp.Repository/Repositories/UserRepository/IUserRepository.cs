using SuperApp.Domain.User;

namespace SuperApp.Repository.Repositories.UserRepository;

public interface IUserRepository
{
    User Insert(User user);
    User Update(User user);
    void Delete(int id);
    List<User> GetAll();
    User GetById(int id);
    
    User GetByEmail(string email);
}