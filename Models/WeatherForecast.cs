using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Weather_React_DotNet_Project.Models
{
    public class WeatherForecast
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ForecastID { get; set; }

        [ForeignKey("Location")]
        public int LocationID { get; set; }

        [ForeignKey("WeatherType")]
        public int TypeID { get; set; }

        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public decimal MinTemperature { get; set; }
        public decimal MaxTemperature { get; set; }
        public decimal ChanceOfPrecipitation { get; set; }

        // Navigation properties
        public virtual Location? Location { get; set; }
        public virtual WeatherType? WeatherType { get; set; }
    }


}
