using AutoMapper;
using SuperApp.Application.Authentication.Commands;
using SuperApp.Domain.Authentication;
using SuperApp.Domain.User;

namespace SuperApp.Infrastructure.Profiles;

public class AuthenticationProfile : Profile
{
    public AuthenticationProfile()
    {
        CreateMap<AuthenticationResultDTO, Authentication>();
        CreateMap<Authentication, AuthenticationResultDTO>();
        
        CreateMap<User, Authentication>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));;
    }
}