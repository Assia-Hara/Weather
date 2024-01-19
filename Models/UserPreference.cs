using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Weather_React_DotNet_Project.Models
{
    public class UserPreference
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PreferenceID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        [ForeignKey("Location")]
        public int LocationID { get; set; }

        [StringLength(50)]
        public string AlertType { get; set; }

        // Navigation properties
        public virtual User? User { get; set; }
        public virtual Location? Location { get; set; }
    }


}
