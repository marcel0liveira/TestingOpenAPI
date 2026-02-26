using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Info.Title = "TestingOpenAPI";
        document.Info.Version = "v1";
        document.Info.Description = "A sample .NET 10 API demonstrating native OpenAPI support without Swagger.";
        return Task.CompletedTask;
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Exposes the OpenAPI JSON document at /openapi/v1.json
    app.MapOpenApi();

    // Scalar is a modern OpenAPI UI — replaces Swagger UI for .NET 9+
    app.MapScalarApiReference(options =>
    {
        options.Title = "TestingOpenAPI";
        options.Theme = ScalarTheme.Purple;
    });
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithSummary("Get a 5-day weather forecast")
.WithDescription("Returns a 5-day weather forecast with random temperatures and summaries.")
.WithTags("Weather");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
