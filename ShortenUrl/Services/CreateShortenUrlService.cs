using System.Security.Cryptography;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace ShortenUrl.Services;

public class CreateShortenUrlService: ICreateShortenUrl
{
    private readonly string caracteres = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    private readonly IVerifyShortenUrlExisty  _verifyShortenUrlExisty;

    public CreateShortenUrlService(IVerifyShortenUrlExisty verifyShortenUrlExisty)
    {
        _verifyShortenUrlExisty = verifyShortenUrlExisty;
    }

    public async Task<string> GeneratedShortenUrl()
    {
        var result = RandomNumberGenerator.GetString(caracteres, 5);

        var verify = await _verifyShortenUrlExisty.VerifyUrl(result);
        
        if (verify)
        {
            GeneratedShortenUrl();
        }
        
        Console.WriteLine("1");
        Console.WriteLine(result);
        
        return result;
    }
    
}