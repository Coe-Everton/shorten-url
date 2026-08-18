using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Driver;
using ShortenUrl.Configs;
using ShortenUrl.Dtos;
using ShortenUrl.Entities;

namespace ShortenUrl.Services;

public class InsertUrlService: IInsertUrl
{
    private readonly IMongoCollection<Urls>? _urls;
    private readonly IValidateUrlSerivce _validateUrlService;
    private readonly ICreateShortenUrl _createShortenUrlService;

    public InsertUrlService(MongoDbService mongoDbService, IValidateUrlSerivce validateUrlService,  ICreateShortenUrl createShortenUrlService)
    {
        _urls = mongoDbService.Database?.GetCollection<Urls>("Urls");
        _validateUrlService = validateUrlService;
        _createShortenUrlService = createShortenUrlService;
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
            ShortUrl = await _createShortenUrlService.GeneratedShortenUrl(),
            ExpiresDate = DateTime.UtcNow.AddHours(1)
        };
        
        await _urls.InsertOneAsync(newUrl);
        
        return newUrl;
    }
}