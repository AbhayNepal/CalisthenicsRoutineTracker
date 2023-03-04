namespace CalisthenicsRoutineTracker.Models
{
    public class Carrier
    {
        public IEnumerable<Workout> carrier_workouts { get; set; }
        public IEnumerable<Date> carrier_date { get; set; }
    }
}
