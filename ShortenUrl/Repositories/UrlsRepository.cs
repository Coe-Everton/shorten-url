using MongoDB.Driver;
using ShortenUrl.Configs;
using ShortenUrl.Entities;
using ShortenUrl.Repositoryies.Interfaces;

namespace ShortenUrl.Repositorys;

public class UrlsRepository: IUrls
{
    private readonly IMongoCollection<Urls>? _urls;
    
    public UrlsRepository (MongoDbService mongo)
    {
        _urls = mongo.Database?.GetCollection<Urls>("Urls");
    }

    public async Task<bool> ValidateExistyShortenUrl(string shortenUrl)
    {
        var result = await _urls.Find(urls => urls.ShortUrl == shortenUrl).FirstOrDefaultAsync();

        if (result is not null)
            return true;
        
        return false;
    }

    public async Task<Urls> GetShortenUrl(string shortenUrl)
    {
        var result = await _urls.Find(shortenUrl => shortenUrl == shortenUrl).FirstOrDefaultAsync();

        return result;
    }

    public async Task<Urls> CreateUrl(Urls url)
    {
        await _urls.InsertOneAsync(url);

        return url;
    }
}