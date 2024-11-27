using AutoMapper;
using SuperApp.Application.Authentication.Commands;
using SuperApp.Application.Authentication.Commands.Register;
using SuperApp.Application.Users;
using SuperApp.Application.Users.Commands.Insert;
using SuperApp.Application.Users.Commands.Update;
using SuperApp.Domain.User;

namespace SuperApp.Infrastructure.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, RegisterUserDTO>();
        CreateMap<InsertUserDTO, User>()
            .ForMember(dest => dest.Id, 
                act => act.Ignore());;
        CreateMap<UpdateUserDTO, User>();
        CreateMap<User, UserDTO>();
        CreateMap<RegisterUserDTO, User>()
            .ForMember(dest => dest.Id, 
                act => act.Ignore());
        
        CreateMap<User, AuthenticationResultDTO>()
            .ForMember(dest => dest.Token,
                opt => opt.Ignore());
    }
}