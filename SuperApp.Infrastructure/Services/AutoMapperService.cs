using AutoMapper;
using SuperApp.Application.Interfaces;
using SuperApp.Infrastructure.Profiles;

namespace SuperApp.Infrastructure.Services;

public class AutoMapperService : IAutoMapperService
{
    private readonly IMapper _mapper;
    
    public AutoMapperService()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfiles(CarregarProfiles()));
        _mapper = config.CreateMapper();
    }

    private IEnumerable<Profile> CarregarProfiles()
    {
        return new List<Profile>()
        {
            new SuperHeroProfile(),
            new UserProfile(),
            new AuthenticationProfile()
        };
    }

    public TDestiny Map<TSource, TDestiny>(TSource source)
    {
        try
        {
            return _mapper.Map<TSource, TDestiny>(source);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<TDestiny> MapList<TSource, TDestiny>(List<TSource> source)
    {
        try
        {
            return _mapper.Map<List<TSource>, List<TDestiny>>(source);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}