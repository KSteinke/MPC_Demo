namespace Application.WeatherService;
public class WeatherService
{
    public async Task<WeatherData> GetPolishWeatherAsync(string city)
    {
        Console.WriteLine($"GetPolishWeatherAsync Service Requested");
        await Task.Delay(5); // API Call delay simulation

        var weather = WeatherDatabase.FirstOrDefault(w => w.City.Equals(city, StringComparison.OrdinalIgnoreCase));
        var result = weather ?? new WeatherData(city, 0, "No Data", 0);
        Console.WriteLine($"GetPolishWeatherAsyncResult service request reqult City: {result.City}, Temp: {result.Temperature}C, Weather: {result.Condition}, Windspeed: {result.WindSpeed} km/h");
        return result;
    }

    private static readonly List<WeatherData> WeatherDatabase = new()
    {
        new WeatherData("Warszawa", 18, "Słonecznie", 10),
        new WeatherData("Kraków", 17, "Pochmurno", 12),
        new WeatherData("Łódź", 16, "Deszcz", 15),
        new WeatherData("Wrocław", 19, "Słonecznie", 8),
        new WeatherData("Poznań", 20, "Słonecznie", 9),
        new WeatherData("Gdańsk", 15, "Mgła", 14),
        new WeatherData("Szczecin", 17, "Pochmurno", 11),
        new WeatherData("Bydgoszcz", 18, "Słonecznie", 10),
        new WeatherData("Lublin", 16, "Deszcz", 13),
        new WeatherData("Białystok", 14, "Wiatr", 20),
        new WeatherData("Katowice", 19, "Słonecznie", 9),
        new WeatherData("Gdynia", 15, "Mgła", 12),
        new WeatherData("Częstochowa", 16, "Pochmurno", 10),
        new WeatherData("Radom", 17, "Deszcz", 13),
        new WeatherData("Sosnowiec", 18, "Słonecznie", 8),
        new WeatherData("Toruń", 19, "Słonecznie", 7),
        new WeatherData("Kielce", 17, "Deszcz", 14),
        new WeatherData("Rzeszów", 16, "Pochmurno", 11),
        new WeatherData("Gliwice", 18, "Wiatr", 15),
        new WeatherData("Zabrze", 19, "Słonecznie", 9),
        new WeatherData("Olsztyn", 15, "Mgła", 10),
        new WeatherData("Bielsko-Biała", 17, "Pochmurno", 12),
        new WeatherData("Rybnik", 18, "Słonecznie", 8),
        new WeatherData("Opole", 19, "Deszcz", 13),
        new WeatherData("Elbląg", 15, "Wiatr", 14),
        new WeatherData("Gorzów Wielkopolski", 16, "Słonecznie", 9),
        new WeatherData("Dąbrowa Górnicza", 17, "Deszcz", 11),
        new WeatherData("Płock", 18, "Pochmurno", 12),
        new WeatherData("Wałbrzych", 19, "Słonecznie", 10),
        new WeatherData("Włocławek", 17, "Deszcz", 14)
    };

    
}

public record WeatherData(string City, int Temperature, string Condition, int WindSpeed);