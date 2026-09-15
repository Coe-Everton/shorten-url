using Microsoft.AspNetCore.Http;

namespace ShortenUrl.Configs;

public enum ErrorType
{
    NotFound = StatusCodes.Status404NotFound,
    Validation =  StatusCodes.Status422UnprocessableEntity,
    Unauthorized  = StatusCodes.Status401Unauthorized,
    BadRequest  = StatusCodes.Status400BadRequest,
    Forbidden   = StatusCodes.Status403Forbidden,
    InternalError =  StatusCodes.Status500InternalServerError,
}

public static class ErrorTypeExtensions
{
    public static int ToStatusCode(this ErrorType errorType) => errorType switch
    {
        ErrorType.NotFound => StatusCodes.Status404NotFound,
        ErrorType.Validation => StatusCodes.Status422UnprocessableEntity,
        ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
        ErrorType.BadRequest => StatusCodes.Status400BadRequest,
        ErrorType.Forbidden => StatusCodes.Status403Forbidden,
        _ => StatusCodes.Status500InternalServerError
    };
}

public record Error(string Id, ErrorType Code, string Description);
