using ShortenUrl.Configs;
using ShortenUrl.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IValidateUrlSerivce, ValidateUrlRequestService>();
builder.Services.AddScoped<IInsertUrl, InsertUrlService>();
builder.Services.AddScoped<ICreateShortenUrl, CreateShortenUrlService>();
builder.Services.AddScoped<IVerifyShortenUrlExisty, VerifyShortenUrlExistyService>();
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
