namespace ShortenUrl.Services;

public interface ICreateShortenUrl
{
    public Task<string> Execute();
    
}