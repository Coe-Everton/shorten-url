using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Driver;
using ShortenUrl.Configs;
using ShortenUrl.Dtos;
using ShortenUrl.Entities;

namespace ShortenUrl.Services;

public class InsertUrl: IInsertUrl
{
    private readonly IMongoCollection<Urls>? _urls;
    private readonly IValidateUrlSerivce _validateUrlService;

    public InsertUrl(MongoDbService mongoDbService, IValidateUrlSerivce validateUrlService)
    {
        _urls = mongoDbService.Database?.GetCollection<Urls>("Urls");
        _validateUrlService = validateUrlService;
    }
    
    public async Task<Urls?> Execute(ShortenUrlResquet request)
    {
        if (!_validateUrlService.ValidateUrl(request.url))
        {
            return null;
        }  
        
        var newUrl = new Urls()
        {
            Id = Guid.CreateVersion7().ToString(),
            Url = request.url,
            ShortUrl = "teste",
            ExpiresDate = DateTime.UtcNow.AddHours(1)
        };
        
        await _urls.InsertOneAsync(newUrl);
        return newUrl;
    }
}