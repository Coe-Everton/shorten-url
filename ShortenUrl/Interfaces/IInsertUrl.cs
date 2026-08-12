using ShortenUrl.Dtos;
using ShortenUrl.Entities;

namespace ShortenUrl.Services;

public interface IInsertUrl
{
    Task<Urls> Execute(ShortenUrlResquet request);
}