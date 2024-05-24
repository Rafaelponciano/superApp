using AutoMapper;
using SuperApp.Application.Authentication.Commands;
using SuperApp.Application.Authentication.Commands.Register;
using SuperApp.Domain.User;

namespace SuperApp.Infrastructure.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, RegisterUserDTO>();
        CreateMap<RegisterUserDTO, User>()
            .ForMember(dest => dest.Id, 
                act => act.Ignore());
        
        CreateMap<User, AuthenticationResultDTO>()
            .ForMember(dest => dest.Token,
                opt => opt.Ignore());
    }
}