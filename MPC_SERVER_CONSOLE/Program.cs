using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol;

var builder = Host.CreateEmptyApplicationBuilder(settings: null);

builder.Services.AddMcpServer() //Create McpServer
    .WithStdioServerTransport() 
    .WithToolsFromAssembly();


builder.Services.AddSingleton(_ =>
{
    var httpClient = new HttpClient()
    {
        BaseAddress = new Uri("https://api.weather.gov")
    };
    httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("weather-tool", "1.0"));
    return httpClient;
});

var app = builder.Build();

await app.RunAsync();