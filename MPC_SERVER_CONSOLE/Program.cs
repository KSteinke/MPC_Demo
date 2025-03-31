using Application.WeatherService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol;

var builder = Host.CreateEmptyApplicationBuilder(settings: null);

builder.Services.AddMcpServer() //Create McpServer
    .WithStdioServerTransport() 
    .WithToolsFromAssembly();


builder.Services.AddSingleton<WeatherService>();

var app = builder.Build();

await app.RunAsync();