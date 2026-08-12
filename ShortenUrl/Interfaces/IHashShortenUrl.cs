namespace ShortenUrl.Services;

public interface IHashShortenUrl
{
    public string GeneratedShortenUrl(string url);
    public bool ValidateShortenUrl(string shortenUrl);
    
}