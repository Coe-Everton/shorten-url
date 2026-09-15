using ShortenUrl.Services;

namespace ShortenUrl.Extensions;

public static class Services
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IRedirectToUrl, RedirectToUrlService>();
        services.AddScoped<IValidateUrlSerivce, ValidateUrlRequestService>();
        services.AddScoped<IInsertUrl, InsertUrlService>();
        services.AddScoped<ICreateShortenUrl, CreateShortenUrlService>();
        services.AddScoped<IVerifyShortenUrlExisty, VerifyShortenUrlExistyService>();

        return services;
    }
}