using WorkerSample.Contracts;
using WorkerSample2.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.UseOrleansClient(clientBuilder =>
{
    clientBuilder.UseLocalhostClustering(gatewayPorts: [30000, 30001]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/ping", (IGrainFactory grainFactory) =>
{
    var grain = grainFactory.GetGrain<IPingGrain>("default");
    return grain.Ping("Hello, World!");
})
.WithName("GetPing")
.WithOpenApi();

app.MapGet("/hello", (IGrainFactory grainFactory) =>
{
    var grain = grainFactory.GetGrain<IHelloWorldGrain>("hello_default");
    return grain.SayHello("Hello, World!");
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
