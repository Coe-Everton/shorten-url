using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json.Serialization;
using ShortenUrl.Configs;
using ShortenUrl.Dtos;
using ShortenUrl.Entities;
using ShortenUrl.Services;
using ShortenUrl.Errors;

namespace ShortenUrl.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ShortenUrlController : ControllerBase
    {
        private readonly IMongoCollection<Urls>? _urls;
        private readonly IInsertUrl _insertUrl;
        private readonly IRedirectToUrl _redirectToUrl;

        public ShortenUrlController(
            MongoDbService mongoDbService,
            IInsertUrl insertUrl,
            IRedirectToUrl redirectToUrl
        )
        {
            _urls = mongoDbService.Database.GetCollection<Urls>("Urls");
            _insertUrl = insertUrl;
            _redirectToUrl = redirectToUrl;
        }
            
        [HttpPost]
        public async Task<ObjectResult> ShortenUrl([FromBody] ShortenUrlResquet request)
        {
            var response = await _insertUrl.Execute(request);
            
            if (response is null)
            {
                return Result.Failure(ErrorsShortenUrl.ShortenUrlNotInserted);
            }

            return Result<Urls>.Sucess(response);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult> GetUrlById(string id)
        {
            var redirect = await _redirectToUrl.Execute(id);
            
            if (redirect is null)
            {
                return Result.Failure(ErrorsShortenUrl.ShortenUrlNotFound);
            }

            return Redirect(redirect.Url);
        }
    }
}
