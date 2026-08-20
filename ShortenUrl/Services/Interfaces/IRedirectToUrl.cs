namespace ShortenUrl.Services;

public interface IRedirectToUrl
{
    public Task<bool> RedirectToUrl(string ShortenUrl);
}