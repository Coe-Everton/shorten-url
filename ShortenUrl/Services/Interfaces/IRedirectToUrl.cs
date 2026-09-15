using ShortenUrl.Entities;

namespace ShortenUrl.Services;

public interface IRedirectToUrl
{
    public Task<Urls> Execute(string ShortenUrl);
}