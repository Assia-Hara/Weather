using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weather_React_DotNet_Project.Models
{
    public class WeatherData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DataID { get; set; }

        [ForeignKey("Location")]
        public int LocationID { get; set; }

        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public decimal Temperature { get; set; }
        public decimal Humidity { get; set; }
        public decimal Pressure { get; set; }
        public decimal WindSpeed { get; set; }
        public string? WindDirection { get; set; }
        public decimal Precipitation { get; set; }
        public string WeatherCondition { get; set; }
        public DateTime Sunrise { get; set; } // Sunrise field
        public DateTime Sunset { get; set; } // Sunset field
        public int Visibility { get; set; } // Visibility field
        public int Cloudiness { get; set; } // Cloudiness field

        // Navigation property
        public virtual Location? Location { get; set; }
    }
}
