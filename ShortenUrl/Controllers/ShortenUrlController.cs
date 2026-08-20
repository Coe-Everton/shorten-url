using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json.Serialization;
using ShortenUrl.Configs;
using ShortenUrl.Dtos;
using ShortenUrl.Entities;
using ShortenUrl.Services;

namespace ShortenUrl.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ShortenUrlController : ControllerBase
    {
        private readonly IMongoCollection<Urls>? _urls;
        private readonly IInsertUrl _insertUrl;

        public ShortenUrlController(
            MongoDbService mongoDbService,
            IInsertUrl insertUrl
        )
        {
            _urls = mongoDbService.Database.GetCollection<Urls>("Urls");
            _insertUrl = insertUrl;
        }
            
        [HttpPost]
        public async Task<ActionResult>  ShortenUrl([FromBody] ShortenUrlResquet request)
        {
            var response = await _insertUrl.Execute(request);

            if (response is null)
            {
                return BadRequest("Url is invalid");
            }
            
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Urls>> GetUrlById(string id)
        {
            
            
            var filter = Builders<Urls>.Filter.Eq(x => x.Id, id);
            var urls = await _urls.Find(filter).FirstOrDefaultAsync();
            return urls is not null ? Ok(urls) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUrlById(string id)
        {
            var filter = Builders<Urls>.Filter.Eq(x => x.Id, id);
            await _urls.DeleteOneAsync(filter);
            return Ok();
        }
    }
}
