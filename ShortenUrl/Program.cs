using ShortenUrl.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMongo().AddServices().AddRepositories();
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseMongoIndexes();

if (app.Environment.IsDevelopment())
{ 
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
