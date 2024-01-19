using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weather_React_DotNet_Project.Models
{
    public class WeatherType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeID { get; set; }

        [StringLength(50)]
        public string? Description { get; set; }

        // Navigation property
        public virtual ICollection<WeatherForecast>? WeatherForecasts { get; set; }
    }


}
