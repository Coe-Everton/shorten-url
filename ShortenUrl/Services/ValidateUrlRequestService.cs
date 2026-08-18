using System.Text.RegularExpressions;

namespace ShortenUrl.Services;

public class ValidateUrlRequestService: IValidateUrlSerivce
{
    public bool ValidateUrl(string url)
    {
        Regex validateUrlRegex =
            new Regex(
                "^https?:\\/\\/(?:www\\.)?[-a-zA-Z0-9@:%._\\+~#=]{1,256}\\.[a-zA-Z0-9()]{1,6}\\b(?:[-a-zA-Z0-9()@:%_\\+.~#?&\\/=]*)$");
        
        return validateUrlRegex.IsMatch(url);
    }
}