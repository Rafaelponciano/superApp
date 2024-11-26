using SuperApp.Domain.User;
using SuperApp.Repository.Data;

namespace SuperApp.Repository.Repositories.UserRepository;

public class UserRepository : IUserRepository
{
    private readonly DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public User Insert(User user)
    {
        _dataContext.Users.Add(user);
        _dataContext.SaveChanges();

        return user;
    }

    public User Update(User user)
    {
        var updateUser = _dataContext.Users.Find(user.Id);
        if (updateUser is null) throw new Exception("NotFound");
        
        updateUser.FirstName = user.FirstName;
        updateUser.LastName = user.LastName;
        updateUser.Email = user.Email;
        updateUser.Password = user.Password;
        
        _dataContext.Users.Update(updateUser);
        _dataContext.SaveChanges();

        return updateUser;
    }

    public void Delete(int id)
    {
        var dbUser = _dataContext.Users.Find(id);
        if (dbUser is null) throw new Exception("NotFound");

        _dataContext.Users.Remove(dbUser);
        _dataContext.SaveChanges();
    }

    public List<User> GetAll()
    {
        var users = _dataContext.Users.ToList();

        return users;
    }

    public User GetById(int id)
    {
        var dbUser = _dataContext.Users.Find(id);
        if (dbUser is null) throw new Exception("NotFound");

        return dbUser;
    }

    public User GetByEmail(string email)
    {
        var dbUser = _dataContext.Users.FirstOrDefault(user => user.Email == email);
        if (dbUser is null) throw new Exception("NotFound");

        return dbUser;
    }
}