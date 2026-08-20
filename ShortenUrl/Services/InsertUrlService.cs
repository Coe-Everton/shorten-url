using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Driver;
using ShortenUrl.Configs;
using ShortenUrl.Dtos;
using ShortenUrl.Entities;
using ShortenUrl.Repositoryies.Interfaces;

namespace ShortenUrl.Services;

public class InsertUrlService: IInsertUrl
{
    private readonly IUrls _UrlsRepository;
    private readonly IValidateUrlSerivce _validateUrlService;
    private readonly ICreateShortenUrl _createShortenUrlService;

    public InsertUrlService(IUrls urlsRepository, IValidateUrlSerivce validateUrlService,  ICreateShortenUrl createShortenUrlService)
    {
        _UrlsRepository = urlsRepository;
        _validateUrlService = validateUrlService;
        _createShortenUrlService = createShortenUrlService;
    }
    
    public async Task<Urls?> Execute(ShortenUrlResquet request)
    {
        if (_validateUrlService.ValidateUrl(request.url))
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

        var result = await _UrlsRepository.CreateUrl(newUrl);
        
        return result;
    }
}