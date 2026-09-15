using ShortenUrl.Repositoryies.Interfaces;
using ShortenUrl.Repositorys;

namespace ShortenUrl.Extensions;

public static class Repositories
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUrls, UrlsRepository>();

        return services;
    }
}