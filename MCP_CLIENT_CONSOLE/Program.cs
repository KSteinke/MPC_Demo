using Microsoft.Extensions.Hosting;
using ModelContextProtocol;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;

var builder = Host.CreateEmptyApplicationBuilder(settings: null);


var client = await McpClientFactory.CreateAsync(new McpServerConfig
{
    Id = "exampleServer",
    Name = "Example Server",
    TransportType = TransportTypes.StdIo,
    TransportOptions = new Dictionary<string, string>
    {
        ["command"] = "dotnet",
        ["arguments"] = "run --project D:\\Projekty\\MPC_Demo\\MPC_SERVER_CONSOLE\\MPC_SERVER_CONSOLE.csproj --no-build"
    }
});

var tools = await client.ListToolsAsync();

// Wypisz dostępne narzędzia na serwerze
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}

// Wywołaj konkretne narzędzie
var result = await client.CallToolAsync(
    tools.FirstOrDefault().Name,
    new Dictionary<string, object?> { ["city"] = "Kraków" },
    CancellationToken.None
);

// Przetwarzanie wyników
Console.WriteLine(result.Content.First(c => c.Type == "text").Text);
