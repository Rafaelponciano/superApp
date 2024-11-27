namespace SuperApp.Application.Users.Queries.GetUser;

public interface IGetUserQuery
{
    Task<UserDTO> Execute(int id);
}