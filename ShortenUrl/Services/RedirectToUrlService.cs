using Microsoft.AspNetCore.Http.HttpResults;

namespace ShortenUrl.Services;

public class RedirectToUrlService : IRedirectToUrl
{
    private readonly IVerifyShortenUrlExisty _verifyShortenUrlExistyService;
    
    public RedirectToUrlService(IVerifyShortenUrlExisty verifyShortenUrlExisty)
    {
        _verifyShortenUrlExistyService =  verifyShortenUrlExisty;
    }

    public async Task<bool> RedirectToUrl(string ShortenUrl)
    {
        var existy = await _verifyShortenUrlExistyService.VerifyUrl(ShortenUrl);
        if (existy)
        {
            return false;
        }
        
        
        
        return true;
    }
}