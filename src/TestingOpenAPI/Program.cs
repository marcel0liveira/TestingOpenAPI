using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    // teste 1
    //app.MapScalarApiReference(options =>
    //{
    //    options
    //    .WithTitle("Testando Scalar no lugar do SwaggerUI")
    //});

    // teste 2
    app.MapScalarApiReference("scalar", options =>
    {
        options.Title = "Testando Scalar no lugar do SwaggerUI";
        options.Theme = ScalarTheme.Mars; // Exemplo de uso das propriedades que você listou
        options.ShowSidebar = true;
        options.OpenApiRoutePattern = "/openapi/{documentName}.json";
    });

    // teste 3
    //app.MapScalarApiReference("scalar", options =>
    //{
    //    // Traduzindo o seu JSON para as propriedades da classe ScalarOptions
    //    options.HideModels = false;
    //    options.HideSearch = false;
    //    options.Title = "Minha API v1";
    //    options.Theme = ScalarTheme.Kepler; // "theme": "kepler"
    //    options.Layout = ScalarLayout.Modern; // "layout": "modern"
    //    options.ShowSidebar = true;
    //    options.HideClientButton = false;
    //    options.ShowOperationId = false;
    //    options.OrderRequiredPropertiesFirst = true;
    //    options.SchemaPropertyOrder = PropertyOrder.Alpha;

    //    // Configurações de visibilidade de ferramentas de dev
    //    options.ShowDeveloperTools = DeveloperToolsVisibility.Localhost;

    //    // Referência ao documento OpenAPI
    //    options.OpenApiRoutePattern = "/openapi/{documentName}.json";
    //});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
