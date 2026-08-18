using MongoDB.Driver;
using ShortenUrl.Configs;
using ShortenUrl.Entities;

namespace ShortenUrl.Services;

public class VerifyShortenUrlExistyService : IVerifyShortenUrlExisty
{
    private  readonly IMongoCollection<Urls>?  _urls;

    public VerifyShortenUrlExistyService(MongoDbService mongoDbService)
    {
        _urls = mongoDbService.Database?.GetCollection<Urls>("Urls");
    }

    public async Task<bool> VerifyUrl(string shortenUrl)
    {
        var result = await _urls.Find(x => x.ShortUrl == shortenUrl).FirstOrDefaultAsync();

        if (result is not null)
        {
            return true;
        }
        
        return false;
    }
    
}