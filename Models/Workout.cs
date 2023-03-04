using System.ComponentModel.DataAnnotations;

namespace CalisthenicsRoutineTracker.Models
{
    public class Workout
    {
        // public DateTime Date { get; set; } = DateTime.Now;
        [Key]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        public int set1_reps { get; set; }
        public int set2_reps { get; set; }
        public int set3_reps { get; set; }
        public int set4_reps { get; set; }
    }
}