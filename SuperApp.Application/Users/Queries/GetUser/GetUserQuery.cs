using SuperApp.Application.Interfaces;
using SuperApp.Application.Users.Contract;
using SuperApp.Domain.User;

namespace SuperApp.Application.Users.Queries.GetUser;

public class GetUserQuery : IGetUserQuery
{
    private readonly IUserService _userService;
    private readonly IAutoMapperService _autoMapper;
    
    public GetUserQuery(IUserService userService, IAutoMapperService autoMapper)
    {
        _userService = userService;
        _autoMapper = autoMapper;
    }
    
    public Task<UserDTO> Execute(int id)
    {
        return Task.FromResult(_autoMapper.Map<User, UserDTO>(_userService.GetById(id)));
    }
}