namespace SuperApp.Application.Heroes.Contract;

public interface IAutoMapperService
{
    TDestiny Map<TSource, TDestiny>(TSource source);

    List<TDestiny> MapList<TSource, TDestiny>(List<TSource> source);
}