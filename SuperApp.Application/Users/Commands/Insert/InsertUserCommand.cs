using SuperApp.Application.Interfaces;
using SuperApp.Application.Users.Contract;
using SuperApp.Domain.User;

namespace SuperApp.Application.Users.Commands.Insert;

public class InsertUserCommand: IInsertUserCommand
{
    private readonly IUserService _userService;
    private readonly IAutoMapperService _autoMapper;

    public InsertUserCommand(IUserService userService, IAutoMapperService autoMapper)
    {
        _userService = userService;
        _autoMapper = autoMapper;
    }

    public UserDTO Execute(InsertUserDTO insertUserDto)
    {
        if (insertUserDto.Password != insertUserDto.ConfirmPassword)
            throw new Exception("Passwords do not match");
        
        var user = _autoMapper.Map<InsertUserDTO, User>(insertUserDto);
        
        return _autoMapper.Map<User, UserDTO>( _userService.Insert(user));
    }
}