using System.Security.Cryptography;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using ShortenUrl.Configs;

namespace ShortenUrl.Services;

public class CreateShortenUrlService: ICreateShortenUrl
{
    private readonly string caracteres = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    private readonly IVerifyShortenUrlExisty  _verifyShortenUrlExisty;

    public CreateShortenUrlService(IVerifyShortenUrlExisty verifyShortenUrlExisty)
    {
        _verifyShortenUrlExisty = verifyShortenUrlExisty;
    }

    public async Task<string> Execute()
    {
        var result = RandomNumberGenerator.GetString(caracteres, 5);

        do
        {
            result = RandomNumberGenerator.GetString(caracteres, 5);
        } while (await _verifyShortenUrlExisty.Execute(result));
        
        return result;
    }
    
}