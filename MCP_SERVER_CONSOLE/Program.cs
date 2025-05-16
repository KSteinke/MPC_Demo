using Application.WeatherService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol;
using Tools.WeatherServerTools;

var builder = Host.CreateEmptyApplicationBuilder(settings: null);

builder.Services.AddMcpServer() //Create McpServer
    .WithStdioServerTransport() 
    .WithToolsFromAssembly();


builder.Services.AddSingleton<WeatherService>();
builder.Services.AddSingleton<WeatherServerTools>();

var app = builder.Build();

await app.RunAsync();