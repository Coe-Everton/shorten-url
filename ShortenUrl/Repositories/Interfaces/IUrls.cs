using ShortenUrl.Entities;

namespace ShortenUrl.Repositoryies.Interfaces;

public interface IUrls
{
    public Task<bool> ValidateExistyShortenUrl(string shortenUrl);
    public Task<Urls> GetShortenUrl(string shortenUrl);
    public Task<Urls> CreateUrl(Urls url);
}