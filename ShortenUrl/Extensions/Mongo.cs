using MongoDB.Driver;
using ShortenUrl.Configs;
using ShortenUrl.Entities;

namespace ShortenUrl.Extensions;

public static class Mongo
{
    public static IServiceCollection AddMongo(this IServiceCollection services)
    {
        services.AddSingleton<MongoDbService>();

        return services;
    }

    public static WebApplication UseMongoIndexes(this WebApplication app)
    {
        var mongoDbService = app.Services.GetRequiredService<MongoDbService>();
        var urls = mongoDbService.Database?.GetCollection<Urls>("Urls");

        var ttlIndex = new CreateIndexModel<Urls>(
            Builders<Urls>.IndexKeys.Ascending(x => x.ExpiresDate),
            new CreateIndexOptions { ExpireAfter = TimeSpan.Zero });

        urls?.Indexes.CreateOne(ttlIndex);

        return app;
    }
}