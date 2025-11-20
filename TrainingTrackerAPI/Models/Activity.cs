using System.ComponentModel.DataAnnotations;

namespace TrainingTrackerAPI.Models
{
    public class Activity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double Distance { get; set; }
    }
}
