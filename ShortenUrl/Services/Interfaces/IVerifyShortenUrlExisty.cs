namespace ShortenUrl.Services;

public interface IVerifyShortenUrlExisty
{
    public Task<bool> Execute(string shortenUrl);
}