using SuperApp.Application.Interfaces;
using SuperApp.Application.Users.Contract;
using SuperApp.Domain.User;

namespace SuperApp.Application.Users.Queries.GetAllUsers;

public class GetAllUsersQuery: IGetAllUsersQuery
{
    private readonly IUserService _userService;
    private readonly IAutoMapperService _autoMapper;
    
    public GetAllUsersQuery(IUserService userService, IAutoMapperService autoMapper)
    {
        _userService = userService;
        _autoMapper = autoMapper;
    }
    
    public Task<List<UserDTO>> Execute()
    {
        var users = _userService.GetAll();

        return Task.FromResult(_autoMapper.MapList<User, UserDTO>(users));
    }
}