using SuperApp.Application.Interfaces;
using SuperApp.Application.Users.Contract;
using SuperApp.Domain.User;

namespace SuperApp.Application.Users.Commands.Update;

public class UpdateUserCommand: IUpdateUserCommand
{
    private readonly IUserService _userService;
    private readonly IAutoMapperService _autoMapper;

    public UpdateUserCommand(IUserService userService, IAutoMapperService autoMapper)
    {
        _userService = userService;
        _autoMapper = autoMapper;
    }

    public UserDTO Execute(UpdateUserDTO updateUserDto)
    {
        if (updateUserDto.Password != updateUserDto.ConfirmPassword)
            throw new Exception("Passwords do not match");
        
        var user = _autoMapper.Map<UpdateUserDTO, User>(updateUserDto);
        
        return _autoMapper.Map<User, UserDTO>( _userService.Update(user));
    }
}