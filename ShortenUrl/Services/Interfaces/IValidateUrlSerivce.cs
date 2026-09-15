namespace ShortenUrl.Services;

public interface IValidateUrlSerivce
{
    public bool Execute(string url);
}