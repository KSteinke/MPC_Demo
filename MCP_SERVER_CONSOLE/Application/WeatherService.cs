using System.Text.Json;

namespace Application.WeatherService;
public class WeatherService
{
    public async Task<string> GetPolishWeatherAsync(string city)
    {
        Console.WriteLine($"GetPolishWeatherAsync Service Requested");
        await Task.Delay(5); // API Call delay simulation

        var weather = WeatherDatabase.FirstOrDefault(w => w.City.Equals(city, StringComparison.OrdinalIgnoreCase));
        var result = weather ?? new WeatherData(city, 0, "No Data", 0);
        string resultJson = JsonSerializer.Serialize(weather);
        Console.WriteLine($"GetPolishWeatherAsyncResult service request reqult City: {resultJson}");
        return resultJson;
    }

    private static readonly List<WeatherData> WeatherDatabase = new()
    {
        new WeatherData("Warszawa", 18, "Sunny", 10),
        new WeatherData("Kraków", 17, "Cloudy", 12),
        new WeatherData("Łódź", 16, "Rain", 15),
        new WeatherData("Wrocław", 19, "Sunny", 8),
        new WeatherData("Poznań", 20, "Sunny", 9),
        new WeatherData("Gdańsk", 15, "Fog", 14),
        new WeatherData("Szczecin", 17, "Cloudy", 11),
        new WeatherData("Bydgoszcz", 18, "Sunny", 10),
        new WeatherData("Lublin", 16, "Rain", 13),
        new WeatherData("Białystok", 14, "Windy", 20),
        new WeatherData("Katowice", 19, "Sunny", 9),
        new WeatherData("Gdynia", 15, "Fog", 12),
        new WeatherData("Częstochowa", 16, "Cloudy", 10),
        new WeatherData("Radom", 17, "Rain", 13),
        new WeatherData("Sosnowiec", 18, "Sunny", 8),
        new WeatherData("Toruń", 19, "Sunny", 7),
        new WeatherData("Kielce", 17, "Rain", 14),
        new WeatherData("Rzeszów", 16, "Cloudy", 11),
        new WeatherData("Gliwice", 18, "Windy", 15),
        new WeatherData("Zabrze", 19, "Sunny", 9),
        new WeatherData("Olsztyn", 15, "Fog", 10),
        new WeatherData("Bielsko-Biała", 17, "Cloudy", 12),
        new WeatherData("Rybnik", 18, "Sunny", 8),
        new WeatherData("Opole", 19, "Rain", 13),
        new WeatherData("Elbląg", 15, "Windy", 14),
        new WeatherData("Gorzów Wielkopolski", 16, "Sunny", 9),
        new WeatherData("Dąbrowa Górnicza", 17, "Rain", 11),
        new WeatherData("Płock", 18, "Cloudy", 12),
        new WeatherData("Wałbrzych", 19, "Sunny", 10),
        new WeatherData("Włocławek", 17, "Rain", 14)
    };

    
}

public record WeatherData(string City, int Temperature, string Condition, int WindSpeed);