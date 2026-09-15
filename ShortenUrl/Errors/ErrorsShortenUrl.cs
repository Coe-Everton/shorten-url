using ShortenUrl.Configs;

namespace ShortenUrl.Errors;

public static class ErrorsShortenUrl
{
    public static Error ShortenUrlNotInserted { get; } =
        new("ShortenUrlNotInserted", ErrorType.BadRequest, "Invalid Url");
    public static Error ShortenUrlNotFound { get; } = new("ShortenUrlNotFound", ErrorType.BadRequest, "Url not found"); 
}