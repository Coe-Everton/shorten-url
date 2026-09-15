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
        if (_validateUrlService.Execute(request.url))
        {
            return null;
        }  

        var result = await _UrlsRepository.CreateUrl(new Urls{            
            Id = Guid.CreateVersion7().ToString(),
            Url = request.url,
            ShortUrl = await _createShortenUrlService.Execute(),
            ExpiresDate = DateTime.UtcNow.AddDays(7)}
        );
        
        return result;
    }
}