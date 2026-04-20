var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte a controllers + swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Ativa Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Redirecionamento HTTPS (pode manter)
app.UseHttpsRedirection();

// Mapeia controllers
app.MapControllers();

// Rota simples para testar
app.MapGet("/", () => "API ESG rodando 🚀");

// Endpoint de exemplo (mantendo o seu)
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = summaries[Random.Shared.Next(summaries.Length)]
        });

    return forecast;
});

app.Run();