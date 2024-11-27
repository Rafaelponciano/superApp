using SuperApp.Domain.User;

namespace SuperApp.Application.Users.Contract;

public interface IUserService
{
    User Insert(User user);
    User Update(User user);
    void Delete(int id);
    List<User> GetAll();
    User GetById(int id);
    User GetByEmail(string email);
    bool CheckPassword(string email, string password);
}