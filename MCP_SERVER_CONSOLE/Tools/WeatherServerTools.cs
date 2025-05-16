using System.ComponentModel;
using Application.WeatherService;
using ModelContextProtocol.Server;

namespace Tools.WeatherServerTools;

[McpServerToolType]
public class WeatherServerTools
{
    private readonly WeatherService _weatherService;

    public WeatherServerTools(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }


    [McpServerTool, Description("Get weather information for a city in Poland")]
    public async Task<string> GetPolishWeather([Description("The Polish city to get weather for.")] string city)
    {
        var weatherData = await _weatherService.GetPolishWeatherAsync(city);
        return weatherData;
    }
}