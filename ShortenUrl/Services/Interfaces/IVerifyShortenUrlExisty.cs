namespace ShortenUrl.Services;

public interface IVerifyShortenUrlExisty
{
    public Task<bool> VerifyUrl(string shortenUrl);
}