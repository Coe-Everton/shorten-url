using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ShortenUrl.Entities;

public class Urls
{
    [BsonId]
    [BsonElement("_id")]
    public string? Id { get; set; }
    
    [BsonElement("url")]
    public string? Url { get; set; }
    
    [BsonElement("shortUrl")]
    public string? ShortUrl { get; set; } 
    
    [BsonElement("expiresDate")]
    public DateTime? ExpiresDate { get; set; }
}