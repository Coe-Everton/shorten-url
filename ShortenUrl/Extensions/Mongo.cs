using MongoDB.Driver;
using ShortenUrl.Configs;

namespace ShortenUrl.Extensions;

public static class Mongo
{
    public static IServiceCollection AddMongo(this IServiceCollection services)
    {
        services.AddSingleton<MongoDbService>();
        
        return services;
    }
}