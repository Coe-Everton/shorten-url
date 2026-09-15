using Microsoft.AspNetCore.Http.HttpResults;
using ShortenUrl.Entities;
using ShortenUrl.Repositoryies.Interfaces;

namespace ShortenUrl.Services;

public class RedirectToUrlService : IRedirectToUrl
{
    private readonly IUrls _urlsRepository;
    
    public RedirectToUrlService(IUrls urlsRepository)
    {
        _urlsRepository =  urlsRepository;
    }

    public async Task<Urls?> Execute(string ShortenUrl)
    {
        var url = await _urlsRepository.GetShortenUrl(ShortenUrl);
        
        if(url is null)
        {
            return null;
        }
        return url;
    }
}