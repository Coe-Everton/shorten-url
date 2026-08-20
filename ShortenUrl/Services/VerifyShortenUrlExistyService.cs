using MongoDB.Driver;
using ShortenUrl.Configs;
using ShortenUrl.Entities;
using ShortenUrl.Repositoryies.Interfaces;

namespace ShortenUrl.Services;

public class VerifyShortenUrlExistyService : IVerifyShortenUrlExisty
{
    private readonly IUrls _UrlsrRepository;

    public VerifyShortenUrlExistyService(IUrls urlsrRepository)
    {
        _UrlsrRepository = urlsrRepository;
    }

    public async Task<bool> VerifyUrl(string shortenUrl)
    {
        var result = _UrlsrRepository.ValidateExistyShortenUrl(shortenUrl);
        
        if (result is not null)
        {
            return true;
        }
        
        return false;
    }
    
}