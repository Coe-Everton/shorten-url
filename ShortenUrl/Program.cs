using ShortenUrl.Configs;
using ShortenUrl.Repositoryies.Interfaces;
using ShortenUrl.Repositorys;
using ShortenUrl.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IValidateUrlSerivce, ValidateUrlRequestService>();
builder.Services.AddScoped<IInsertUrl, InsertUrlService>();
builder.Services.AddScoped<ICreateShortenUrl, CreateShortenUrlService>();
builder.Services.AddScoped<IVerifyShortenUrlExisty, VerifyShortenUrlExistyService>();
builder.Services.AddScoped<IRedirectToUrl, RedirectToUrlService>();
builder.Services.AddScoped<IUrls, UrlsRepository>();
builder.Services.AddOpenApi();
builder.Services.AddSingleton<MongoDbService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
