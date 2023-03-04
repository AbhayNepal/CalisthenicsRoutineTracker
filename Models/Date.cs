namespace CalisthenicsRoutineTracker.Models
{
    public class Date
    {
        public List<Workout> workouts { get; set; }
        public  int Id {get; set;}
        public DateTime date { get; set; } = DateTime.Now;
    }

}