using Newtonsoft.Json;

public class OpenWeatherResponse
{
    // Other properties

    [JsonProperty("weather")]
    public List<WeatherInfo> Weather { get; set; }

    [JsonProperty("sys")]
    public SysInfo Sys { get; set; }

    [JsonProperty("visibility")]
    public int Visibility { get; set; }

    [JsonProperty("clouds")]
    public CloudsInfo Clouds { get; set; }

    public MainInfo Main { get; set; }
    // Other properties
}

public class WeatherInfo
{
    [JsonProperty("description")]
    public string Description { get; set; }

    // Add other weather-related properties as needed
}

public class SysInfo
{
    [JsonProperty("sunrise")]
    public long Sunrise { get; set; }

    [JsonProperty("sunset")]
    public long Sunset { get; set; }

    // Add other sys-related properties as needed
}

public class CloudsInfo
{
    [JsonProperty("all")]
    public int All { get; set; }

    // Add other clouds-related properties as needed
}
public class MainInfo
{
    [JsonProperty("temp")]
    public double Temp { get; set; }

    [JsonProperty("humidity")]
    public int Humidity { get; set; }

    [JsonProperty("pressure")]
    public int Pressure { get; set; }

    // Add other main-related properties as needed
}