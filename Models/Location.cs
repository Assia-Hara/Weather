using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weather_React_DotNet_Project.Models
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationID { get; set; }

        [StringLength(100)]
        public string? City { get; set; }

        [StringLength(100)]
        public string? StateProvince { get; set; }

        [StringLength(100)]
        public string? Country { get; set; }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        // Navigation properties
        public virtual ICollection<WeatherData>? WeatherData { get; set; }
        public virtual ICollection<WeatherForecast>? WeatherForecasts { get; set; }
    }
}
