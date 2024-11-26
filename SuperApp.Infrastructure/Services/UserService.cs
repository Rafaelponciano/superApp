using Microsoft.EntityFrameworkCore;
using SuperApp.Application.Authentication.Contract;
using SuperApp.Application.Users.Contract;
using SuperApp.Domain.User;
using SuperApp.Repository.Data;
using SuperApp.Repository.Repositories.UserRepository;

namespace SuperApp.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User Insert(User user)
    {
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        return _userRepository.Insert(user);
    }

    public User Update(User user)
    {
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        return _userRepository.Update(user);
    }

    public void Delete(int id)
    {
        _userRepository.Delete(id);
    }

    public List<User> GetAll()
    {
        return _userRepository.GetAll();
    }

    public User GetById(int id)
    {
        return _userRepository.GetById(id);
    }

    public User GetByEmail(string email)
    {
        return _userRepository.GetByEmail(email);
    }
    
    public bool CheckPassword(string email, string password)
    {
        var user = _userRepository.GetByEmail(email);
        if (user is null) return false;
        
        return BCrypt.Net.BCrypt.Verify(password, user.Password);
    }
}