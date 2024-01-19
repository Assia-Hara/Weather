namespace Weather_React_DotNet_Project.Models
{
	public class OpenWeatherForecastResponse
	{
		// Define properties based on the structure of the OpenWeatherMap forecast API response
		public List<ForecastItem> List { get; set; }
		// Add other properties if needed
	}

	public class ForecastItem
	{
		// Define properties based on the structure of each forecast item
		public DateTime DtTxt { get; set; }
		public MainInfo Main { get; set; }
		// Add other properties if needed
	}

	public class MainInfo
	{
		// Define properties based on the structure of the main information in each forecast item
		public double Temp { get; set; }
		public int Humidity { get; set; }
		public double Pressure { get; set; }
		// Add other properties if needed
	}
}
