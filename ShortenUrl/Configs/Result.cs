using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShortenUrl.Configs;

public record Result() 
{
    public bool IsSuccess { get; }
    public Error? Error { get; }

    protected Result(bool isSuccess, Error? error) : this()
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Sucess() => new(true, null);
    public static Result Failure(Error error) => new(false, error ?? throw new ArgumentNullException(nameof(error)));

    public static implicit operator Result(Error error) => Failure(error);

    public static implicit operator ObjectResult(Result result) => new(result)
    {
        StatusCode = result.IsSuccess ? StatusCodes.Status200OK : result.Error!.Code.ToStatusCode()
    };
}

public record Result<T> : Result
{
    public T? Data { get; }

    private Result(T data) : base(true, null) => Data = data;
    private Result(Error error) : base(false, error) { }

    public static Result<T> Sucess(T data) => new(data);

    public static implicit operator Result<T>(T value) => new(value);
    public static implicit operator Result<T>(Error error) => new(error);
}
