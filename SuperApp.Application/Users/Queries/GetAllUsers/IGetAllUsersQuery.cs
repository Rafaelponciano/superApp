namespace SuperApp.Application.Users.Queries.GetAllUsers;

public interface IGetAllUsersQuery
{
    Task<List<UserDTO>> Execute();
}